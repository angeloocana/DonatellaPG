using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.WebPages;
using Donatella.Helpers;
using Donatella.Infrastructure;
using Donatella.Infrastructure.Adapters;
using Donatella.Infrastructure.IocRegistry;
using Donatella.Infrastructure.Tasks;
using Donatella.Models.Binders;
using Donatella.Models.Enums;
using Donatella.Models.Login;
using Newtonsoft.Json;
using Pol.Infrastructure.IocRegistry;
using StructureMap;
using Donatella.Infrastructure.Ioc;

namespace Donatella
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(DateTime?), new MyDateTimeModelBinder());

            DependencyResolver.SetResolver(new StructureMapDependecyResolver(() => Container ?? ObjectFactory.Container));

            ObjectFactory.Configure(cfg =>
            {
                cfg.AddRegistry(new StandardRegistry());
                cfg.AddRegistry(new ControllerRegistry());
                cfg.AddRegistry(new DataRegistry());
                cfg.AddRegistry(new ActionFilterRegistry(() => Container ?? ObjectFactory.Container));
                cfg.AddRegistry(new TaskRegistry());
                cfg.AddRegistry(new ModelMetadataRegistry());
            });

            using (var container = ObjectFactory.Container.GetNestedContainer())
            {
                foreach (var task in container.GetAllInstances<IRunAtInit>())
                    task.Execute();

                foreach (var task in container.GetAllInstances<IRunAtStartup>())
                    task.Execute();
            }

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "MyNewResource";
            DefaultModelBinder.ResourceClassKey = "MyNewResource";

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(MyRequiredAttributeAdapter));
            
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        private const string ContainerKey = "_Container";

        public IContainer Container
        {
            get
            {
                return (IContainer)HttpContext.Current.Items[ContainerKey];
            }
            set
            {
                HttpContext.Current.Items[ContainerKey] = value;
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            var serializeModel = JsonConvert.DeserializeObject<UsuarioLogadoViewModel>(authTicket.UserData);
            if (serializeModel == null)
                return;

            var newUser = new LoginPrincipal(serializeModel);

            HttpContext.Current.User = newUser;
        }

        public void Application_BeginRequest()
        {
            Container = ObjectFactory.Container.GetNestedContainer();

            foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
                task.Execute();
        }

        public void Application_Error()
        {
            if (Container == null)
                return;

            foreach (var task in Container.GetAllInstances<IRunOnError>())
                task.Execute();

            //Response.Redirect("~/Erro");
        }

        public void Application_EndRequest()
        {
            if (Container == null)
                return;

            try
            {
                foreach (var task in
                    Container.GetAllInstances<IRunAfterEachRequest>())
                    task.Execute();
            }
            finally
            {
                Container.Dispose();
                Container = null;
            }
        }

        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg == "IsLoggedIn")
            {
                if (context.Request.Cookies[".ASPXAUTH"] != null)
                {
                    return context.Request.Cookies[".ASPXAUTH"].Value;
                }
                else
                {
                    return "anon";
                }
            }
            else
            {
                return base.GetVaryByCustomString(context, arg);
            }

        }
    }
}