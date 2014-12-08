using System;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models.Enums;
using Donatella.Models.Pedidos;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class PedidoController : BaseController
    {
        private readonly ICategoriaApp _categoriaApp;
        private readonly IUsuarioApp _usuarioApp;
        private readonly IPedidoApp _pedidoApp;

        public PedidoController(ICategoriaApp categoriaApp, IUsuarioApp usuarioApp, IPedidoApp pedidoApp)
        {
            _categoriaApp = categoriaApp;
            _usuarioApp = usuarioApp;
            _pedidoApp = pedidoApp;
        }

        public ActionResult Index()
        {
            var model = _categoriaApp.Produtos();
            return View("Pedido", model);
        }

        public PartialViewResult FecharPedido()
        {
            var model = _usuarioApp.DadosParaFecharPedido(UsuarioLogado.CurrentUser.UserId);
            return PartialView("_FecharPedido", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string FecharPedido(FecharPedidoFormViewModel model)
        {
            try
            {
                _pedidoApp.FecharPedido(model, UsuarioLogado.CurrentUser.UserId);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string MudarStatus(int pedidoId, TipoStatusPedido status)
        {
            try
            {
                _pedidoApp.MudarStatus(pedidoId, status);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ActionResult MeusPedidos()
        {
            var model = _pedidoApp.Pedidos(UsuarioLogado.CurrentUser.UserId, new BuscaPedidoFormViewModel { IsAdmin = false });
            model.IsAdmin = false;
            return View(model);
        }

        public ActionResult Pedidos()
        {
            return View(new BuscaPedidoFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaPedidos(BuscaPedidoFormViewModel model)
        {
            model.IsAdmin = true;
            var pedidos = _pedidoApp.Pedidos(null, model);
            return View("_BuscaPedido", pedidos);
        }
    }
}
