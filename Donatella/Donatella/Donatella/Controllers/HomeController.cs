using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Donatella.Filters;
using Donatella.Models;
using Donatella.Data.Entities;
using Donatella.Controllers;
using Donatella.App.Interface;
using Donatella.Helpers;

namespace Donatella.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public HomeController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [LogActionFilter]
        [CustomAuthorize]
        public async Task<ActionResult> Index()
        {
            return View("Home");
        }

        [OutputCache(Duration = 30, VaryByCustom = "IsLoggedIn", VaryByParam = "*", Location = OutputCacheLocation.Server)]
        public async Task<ActionResult> Topo()
        {
            var model = _usuarioApp.Topo(UsuarioLogado.CurrentUser.UserId, UsuarioLogado.CurrentUser.UserId);
            return PartialView("Topo", model);
        }
    }
}
