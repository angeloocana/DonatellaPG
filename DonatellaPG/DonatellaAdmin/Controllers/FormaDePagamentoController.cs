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
    public class FormaDePagamentoController : Controller
    {
        private readonly IFormaDePagamentoRepository _formaDePagamentoRepository;

        public FormaDePagamentoController(IFormaDePagamentoRepository formaDePagamentoRepository)
        {
            _formaDePagamentoRepository = formaDePagamentoRepository;
        }
        
        public ActionResult Index()
        {
            return View("FormasDePagamento", _formaDePagamentoRepository.FormaDePagamentos);
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var formaDePagamento = id > 0 ? _formaDePagamentoRepository.FormaDePagamentos.FirstOrDefault(c => c.FormaDePagamentoId == id)
                : new FormaDePagamento();

            if (formaDePagamento != null) return View("FormaDePagamento", formaDePagamento);

            TempData["Alerta"] = "Forma de pagamento não encontrada!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(FormaDePagamento formaDePagamento)
        {
            if(!ModelState.IsValid)
                return View("FormaDePagamento", formaDePagamento);

            try
            {
                _formaDePagamentoRepository.Salvar(formaDePagamento);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("FormaDePagamento", formaDePagamento);
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
                _formaDePagamentoRepository.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}