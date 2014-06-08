using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonatellaAdmin.infrastructure;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaAdmin.Controllers
{
    [CustomAuthorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public ActionResult Index()
        {
            return View("Categorias", _categoriaRepository.Categorias);
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var categoria = id > 0 ? _categoriaRepository.Categorias.FirstOrDefault(c => c.CategoriaId == id)
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
                _categoriaRepository.Salvar(categoria);
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
                _categoriaRepository.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}