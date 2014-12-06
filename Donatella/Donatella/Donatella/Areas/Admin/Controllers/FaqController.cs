using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Models;
using Donatella.Models.Enums;

namespace Donatella.Areas.Admin.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqApp _faqApp;

        public FaqController(IFaqApp faqApp)
        {
            _faqApp = faqApp;
        }

        #region //== FAQ ==//
        [CustomAuthorize(Permissao = Permissoes.CadastroFaq)]
        [LogActionFilter]
        public async Task<ActionResult> ListarFAQ()
        {
            return View(_faqApp.Faqs());
        }


        [LogActionFilter]
        [CustomAuthorize(Permissao = Permissoes.CadastroFaq)]
        public async Task<ActionResult> CadastrarFAQ(int? id)
        {
            var _model = id > 0 ? _faqApp.Faq(id.Value) : new FaqFormViewModel();
            return View(_model);
        }

        [LogActionFilter]
        [CustomAuthorize(Permissao = Permissoes.CadastroFaq)]
        public async Task<ActionResult> RemoverFAQ(int id)
        {
            _faqApp.RemoverFaq(id);

            return RedirectToAction("ListarFAQ");
        }

        [HttpPost, ValidateAntiForgeryToken]

        [CustomAuthorize(Permissao = Permissoes.CadastroFaq)]
        public async Task<ActionResult> CadastrarFAQ(FaqFormViewModel faqmodel)
        {
            if (!ModelState.IsValid)
                return View(faqmodel);

            _faqApp.SalvarFaq(faqmodel);

            return RedirectToAction("ListarFAQ");
        }
        #endregion

        #region //== FAQGRUPO ==//

        [CustomAuthorize(Permissao = Permissoes.CadastroGrupoFaq)]
        [LogActionFilter]
        public async Task<ActionResult> CadastrarFAQGrupo(int? id)
        {
            var _model = id > 0 ? _faqApp.Grupo(id.Value) : new FaqGrupoFormViewModel();
            return View(_model);
        }

        //== INICIO / LISTAGEM FAQGRUPO
        [CustomAuthorize(Permissao = Permissoes.CadastroGrupoFaq)]
        [LogActionFilter]
        public async Task<ActionResult> ListarFAQGrupo()
        {
            return View(_faqApp.Grupos());
        }

        //== CADASTRAR / ATUALIZAR FAQGRUPO
        [HttpPost, ValidateAntiForgeryToken]
        [CustomAuthorize(Permissao = Permissoes.CadastroGrupoFaq)]
        public async Task<ActionResult> CadastrarFAQGrupo(FaqGrupoFormViewModel faqgrupomodel)
        {
            if (!ModelState.IsValid)
                return View(faqgrupomodel);

            _faqApp.SalvarGrupoFaq(faqgrupomodel);

            return RedirectToAction("ListarFAQGrupo");
        }

        //== REMOVER FAQGRUPO
        [CustomAuthorize(Permissao = Permissoes.CadastroGrupoFaq)]
        [LogActionFilter]
        public async Task<ActionResult> RemoverFAQGrupo(int id)
        {
            _faqApp.RemoverFaqGrupo(id);
            return RedirectToAction("ListarFAQGrupo");
        }
        #endregion
    }
}
