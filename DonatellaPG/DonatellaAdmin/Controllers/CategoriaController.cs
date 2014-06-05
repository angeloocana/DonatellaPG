using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaAdmin.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        //
        // GET: /Categoria/
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

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            var alerta = "Categoria não encontrada!";
            try
            {
                _categoriaRepository.Salvar(categoria);
            }
            catch (Exception ex)
            {
                alerta = ex.Message;
            }

            TempData["Alerta"] = alerta;
            return RedirectToAction("Index");
        }

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