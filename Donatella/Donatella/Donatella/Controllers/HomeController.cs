using System.Web.Mvc;
using Donatella.Filters;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class HomeController : BaseController
    {
        [LogActionFilter]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pedido");
        }
    }
}
