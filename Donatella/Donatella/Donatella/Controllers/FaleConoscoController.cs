using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models;


namespace Donatella.Controllers
{
    public class FaleConoscoController : BaseController
    {
        private readonly IFaleConoscoApp _faleConoscoApp;

        public FaleConoscoController(IFaleConoscoApp faleConoscoApp)
        {
            _faleConoscoApp = faleConoscoApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            var model = UsuarioLogado.Logado ? _faleConoscoApp.DadosFaleConosco(UsuarioLogado.CurrentUser.UserId)
                : new FaleConoscoFormViewModel();
            return View("FaleConosco", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> FaleConosco(FaleConoscoFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _faleConoscoApp.SalvarFaleConosco(model, UsuarioLogado.Logado ? UsuarioLogado.CurrentUser.UserId : (int?)null);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", "Erro ao enviar fale conosco.");
                return View(model);
            }

            return RedirectToAction("FaleConoscoOk");
        }

        [LogActionFilter]
        public async Task<ActionResult> FaleConoscoOk()
        {
            return View();
        }
    }
}
