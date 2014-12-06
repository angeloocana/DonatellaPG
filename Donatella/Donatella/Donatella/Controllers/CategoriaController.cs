using System;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Filters;
using Donatella.Models.Categorias;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaApp _categoriaApp;

        public CategoriaController(ICategoriaApp categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        public ActionResult Index()
        {
            return View("Categorias", _categoriaApp.Categorias());
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var categoria = id > 0 ? _categoriaApp.Categoria(id.Value)
                : new CategoriaViewModel();

            if (categoria != null) return View("Categoria", categoria);

            TempData["Alerta"] = "Categoria não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid)
                return View("Categoria", categoria);

            try
            {
                _categoriaApp.Salvar(categoria);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("Categoria", categoria);
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
                _categoriaApp.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}