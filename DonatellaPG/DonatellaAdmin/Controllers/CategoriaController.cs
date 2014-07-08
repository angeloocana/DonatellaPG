using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonatellaAdmin.infrastructure;
using Application.Interfaces;
using Domain.Entities;


namespace DonatellaAdmin.Controllers
{
    [CustomAuthorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaApp _categoriaApp;

        public CategoriaController(ICategoriaApp categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        public ActionResult Index()
        {
            return View("Categorias", _categoriaApp.Categorias);
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var categoria = id > 0 ? _categoriaApp.Categorias.FirstOrDefault(c => c.CategoriaId == id)
                : new Categoria();

            if (categoria != null) return View("Categoria", categoria);

            TempData["Alerta"] = "Categoria não encontrada!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            if(!ModelState.IsValid)
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