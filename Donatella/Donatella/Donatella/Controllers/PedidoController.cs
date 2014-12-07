using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Donatella.App.Interface;

namespace Donatella.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly ICategoriaApp _categoriaApp;

        public PedidoController(ICategoriaApp categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        public ActionResult Index()
        {
            var model = _categoriaApp.Produtos();
            return View("Pedido",model);
        }
    }
}
