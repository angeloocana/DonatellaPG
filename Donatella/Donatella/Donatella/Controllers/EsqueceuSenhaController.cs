using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models;

namespace Donatella.Controllers
{
    public class EsqueceuSenhaController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public EsqueceuSenhaController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            return View("EsqueceuSenha");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EsqueceuSenhaFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("EsqueceuSenha", model);

            try
            {
                _usuarioApp.EnviaEsqueciSenhaToken(model);
                return RedirectToAction("EmailEnviado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);
                return View("EsqueceuSenha", model);
            }
        }

        [LogActionFilter]
        public async Task<ActionResult> EmailEnviado()
        {
            return View();
        }

        [LogActionFilter]
        public async Task<ActionResult> TrocaSenha(string token)
        {
            return View(new TrocaSenhaFormViewModel { TokenSenha = token });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> TrocaSenha(TrocaSenhaFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _usuarioApp.TrocaSenha(model);
                return RedirectToAction("TrocaSenhaOk");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);
                return View(model);
            }
        }

        [LogActionFilter]
        public async Task<ActionResult> TrocaSenhaOk()
        {
            return View();
        }
    }
}
