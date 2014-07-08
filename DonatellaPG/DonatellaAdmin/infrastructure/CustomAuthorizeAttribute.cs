using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Domain.Entities;

namespace DonatellaAdmin.infrastructure
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated) return;

            //var authorizedUsers = "Admin";
            var authorizedRoles = "";
            var permissoes = Enum.GetValues(typeof (Permissao)).Cast<Permissao>().ToArray();
            for (var i = 0; i < permissoes.Count(); i++)
            {
                authorizedRoles += permissoes[i] + (i < permissoes.Count() - 1 ? "," : "");
            }

            //Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
            Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;

            if (!String.IsNullOrEmpty(Roles))
            {
                if (!CurrentUser.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Loging", action = "Index" }));

                    // base.OnAuthorization(filterContext); //returns to login url
                }
            }

            //if (String.IsNullOrEmpty(Users)) return;

            //if (!Users.Contains(CurrentUser.UserId.ToString()))
            //{
            //    filterContext.Result = new RedirectToRouteResult(new
            //        RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

            //    // base.OnAuthorization(filterContext); //returns to login url
            //}
        }
    }
}