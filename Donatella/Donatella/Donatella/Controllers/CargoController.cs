using System;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Filters;
using Donatella.Models.Cargos;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class CargoController : BaseController
    {
        private readonly ICargoApp _cargoApp;

        public CargoController(ICargoApp cargoApp)
        {
            _cargoApp = cargoApp;
        }
        
        public ActionResult Index()
        {
            return View("Cargos", _cargoApp.Cargos());
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var cargo = id > 0 ? _cargoApp.Cargo(id.Value)
                : new CargoViewModel();

            if (cargo != null) return View("Cargo", cargo);

            TempData["Alerta"] = "Cargo não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(CargoViewModel cargo)
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