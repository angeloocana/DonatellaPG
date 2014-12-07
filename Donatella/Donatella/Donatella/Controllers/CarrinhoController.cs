using System;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Helpers;

namespace Donatella.Controllers
{
    public class CarrinhoController : BaseController
    {
        private readonly ICarrinhoApp _carrinhoApp;

        public CarrinhoController(ICarrinhoApp carrinhoApp)
        {
            _carrinhoApp = carrinhoApp;
        }

        public ActionResult Index()
        {
            return View("Carrinho");
        }

        public PartialViewResult Carrinho()
        {
            var model = _carrinhoApp.Carrinho(UsuarioLogado.CurrentUser.UserId);
            return PartialView("_Carrinho", model);
        }

        [HttpPost]
        public string Add(int id, int qtd)
        {
            try
            {
                _carrinhoApp.Add(UsuarioLogado.CurrentUser.UserId, id, qtd);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string Remove(int id, int? qtd)
        {
            try
            {
                _carrinhoApp.Remove(UsuarioLogado.CurrentUser.UserId, id, qtd);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string Clean()
        {
            try
            {
                _carrinhoApp.Clean(UsuarioLogado.CurrentUser.UserId);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
