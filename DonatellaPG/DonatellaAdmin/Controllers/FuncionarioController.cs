﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonatellaAdmin.infrastructure;
using DonatellaAdmin.Models;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaAdmin.Controllers
{
    [CustomAuthorize]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICargoRepository _cargoRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, ICargoRepository cargoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
        }

        public ActionResult Index()
        {
            return View("Funcionarios", _funcionarioRepository.Funcionarios);
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var funcionario = id > 0 ? _funcionarioRepository.Funcionarios.FirstOrDefault(c => c.FuncionarioId == id)
                : new Funcionario();

            if (funcionario != null)
            {
                if (funcionario.Cargo == null)
                    funcionario.Cargo = new Cargo();

                var model = new FuncionarioViewModel()
                {
                    Funcionario = funcionario,
                    Permissoes = funcionario.Permissoes == null
                        ? new List<Permissao>()
                        : funcionario.Permissoes.Select(p => p.Permissao),
                    Cargos = _cargoRepository.Cargos.ToList().Select(c => 
                        new SelectListItem() { Text = c.NomeCargo, Value = c.CargoId.ToString() })
                };
                return View("Funcionario", model);
            }

            TempData["Alerta"] = "Funcionario não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(FuncionarioViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Funcionario", model);

            try
            {
                _funcionarioRepository.Salvar(model.Funcionario, model.Senha, model.Permissoes);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("Funcionario", model);
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
            
                _funcionarioRepository.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}