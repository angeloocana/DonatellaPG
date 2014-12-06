using System.Linq;
using System.Web.Mvc;

namespace Donatella.Controllers
{
    public class BaseController : Controller
    {
        public string Erro
        {
            get
            {
                return ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).Aggregate((a, b) => a + "; " + b);
            }
        }

        public void Alertar(string msg)
        {
            TempData["Alerta"] = msg;
        }
    }
}
