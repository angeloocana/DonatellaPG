using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Controllers;
using Donatella.Data.Entities;
using Donatella.Filters;
using Donatella.Models.Enums;

namespace Donatella.Areas.Admin.Controllers
{
    [CustomAuthorize(Permissao = Permissoes.Admin)]
    public class HomeController : BaseController
    {
        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            return View("Home");
        }

        public PartialViewResult Menu()
        {
            return PartialView();
        }

        public PartialViewResult Topo()
        {
            return PartialView();
        }
    }
}
