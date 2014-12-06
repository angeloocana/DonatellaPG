using System.Web.Mvc;
using System.Web.Routing;
using Donatella.App.Interface;
using Donatella.Helpers;
using Donatella.Models.Enums;
using Donatella.Models.Login;


namespace Donatella.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public Permissoes Permissao { get; set; }

        public IUsuarioApp UsuarioApp { get; set; }
        public ILogApp LogApp { get; set; }
        
        protected virtual LoginPrincipal CurrentUser
        {
            get { return System.Web.HttpContext.Current.User as LoginPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!UsuarioAutorizado())
                filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }

        private bool UsuarioAutorizado()
        {
            if (CurrentUser == null || !(CurrentUser.UserId > 0))
                return false;

            return Permissao == Permissoes.Site || CurrentUser.IsInRole(Permissao.ToString());
        }
    }
}