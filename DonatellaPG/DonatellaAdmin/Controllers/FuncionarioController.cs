using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonatellaAdmin.Models;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaAdmin.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
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
                var model = new FuncionarioViewModel()
                {
                    Funcionario = funcionario
                };
                return View("Funcionario", model);
            }

            TempData["Alerta"] = "Funcionario não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(FuncionarioViewModel funcionario)
        {
            if (!ModelState.IsValid)
                return View("Funcionario", funcionario);
            
            try
            {
                _funcionarioRepository.Salvar(funcionario.Funcionario, funcionario.Senha,funcionario.Permissoes);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("Funcionario", funcionario);
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