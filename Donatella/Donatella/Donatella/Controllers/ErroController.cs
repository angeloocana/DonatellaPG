using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Donatella.Controllers
{
    public class ErroController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View("Erro");
        }
    }
}
