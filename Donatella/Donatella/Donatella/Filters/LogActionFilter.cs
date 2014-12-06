using System;
using System.Web.Mvc;
using System.Web.Routing;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Helpers;


namespace Donatella.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {

        public ILogApp LogApp { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Log(filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Log("OnResultExecuted", filterContext.RouteData);
        }

        private void Log(RouteData routeData)
        {
            try
            {
                var controllerName = routeData.Values["controller"];
                var actionName = routeData.Values["action"];
                var actionArea = routeData.DataTokens["area"] ?? "";

                var usuario = UsuarioLogado.CurrentUser;
                var usuarioId = usuario == null ? (int?)null : usuario.UserId;
                var logId = usuario == null ? (int?)null : usuario.LogId;

                var log = new Log()
                {
                    Action = actionName.ToString(),
                    Controller = controllerName.ToString(),
                    LogIdPai = logId > 0 ? logId : (int?)null,
                    UsuarioId = usuarioId,
                    Ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"],
                    Area = actionArea.ToString()
                };
                LogApp.SalvarLog(log);
            }
            catch (Exception)
            {
            }
        }
    }
}