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
    public class CargoController : Controller
    {
        private readonly ICargoApp _cargoApp;

        public CargoController(ICargoApp cargoApp)
        {
            _cargoApp = cargoApp;
        }
        
        public ActionResult Index()
        {
            return View("Cargos", _cargoApp.Cargos);
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var cargo = id > 0 ? _cargoApp.Cargos.FirstOrDefault(c => c.CargoId == id)
                : new Cargo();

            if (cargo != null) return View("Cargo", cargo);

            TempData["Alerta"] = "Cargo não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(Cargo cargo)
        {
            if (!ModelState.IsValid)
                return View("Cargo", cargo);

            try
            {
                _cargoApp.Salvar(cargo);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("Cargo", cargo);
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
                _cargoApp.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}