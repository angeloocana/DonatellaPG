using System;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Filters;
using Donatella.Models.FormaDePagamentos;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class FormaDePagamentoController : BaseController
    {
        private readonly IFormaDePagamentoApp _formaDePagamentoApp;

        public FormaDePagamentoController(IFormaDePagamentoApp formaDePagamentoApp)
        {
            _formaDePagamentoApp = formaDePagamentoApp;
        }

        public ActionResult Index()
        {
            return View("FormaDePagamentos", _formaDePagamentoApp.FormaDePagamentos());
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var formaDePagamento = id > 0 ? _formaDePagamentoApp.FormaDePagamento(id.Value)
                : new FormaDePagamentoViewModel();

            if (formaDePagamento != null) return View("FormaDePagamento", formaDePagamento);

            TempData["Alerta"] = "FormaDePagamento não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(FormaDePagamentoViewModel formaDePagamento)
        {
            if (!ModelState.IsValid)
                return View("FormaDePagamento", formaDePagamento);

            try
            {
                _formaDePagamentoApp.Salvar(formaDePagamento);
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
                _formaDePagamentoApp.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}