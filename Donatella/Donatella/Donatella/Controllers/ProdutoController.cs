using System;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Models.Produtos;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoApp _produtoApp;

        public ProdutoController(IProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;
        }
        
        public ActionResult Index()
        {
            return View("Produtos", _produtoApp.Produtos());
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var produto = id > 0 ? _produtoApp.Produto(id.Value)
                : new ProdutoFormViewModel();

            if (produto != null) return View("Produto", produto);

            TempData["Alerta"] = "Produto não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(ProdutoFormViewModel produto)
        {
            if (!ModelState.IsValid)
                return View("Produto", produto);

            try
            {
                _produtoApp.Salvar(produto);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("Produto", produto);
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
                _produtoApp.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}