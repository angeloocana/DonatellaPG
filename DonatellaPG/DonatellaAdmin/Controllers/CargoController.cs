using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaAdmin.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        
        public ActionResult Index()
        {
            return View("Cargos", _cargoRepository.Cargos);
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var cargo = id > 0 ? _cargoRepository.Cargos.FirstOrDefault(c => c.CargoId == id)
                : new Cargo();

            if (cargo != null) return View("Cargo", cargo);

            TempData["Alerta"] = "Cargo não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(Cargo cargo)
        {
            var alerta = "Cargo não encontrado!";
            try
            {
                _cargoRepository.Salvar(cargo);
            }
            catch (Exception ex)
            {
                alerta = ex.Message;
            }

            TempData["Alerta"] = alerta;
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
                _cargoRepository.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}