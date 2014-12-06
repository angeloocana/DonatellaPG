using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Controllers;
using Donatella.Filters;
using Donatella.Models;
using Donatella.Models.Enums;

namespace Donatella.Areas.Admin.Controllers
{
    [CustomAuthorize(Permissao = Permissoes.CadastroPerfilPermissoes)]
    public class PerfilController : BaseController
    {
        private readonly IPermissaoApp _permissaoApp;

        public PerfilController(IPermissaoApp permissaoApp)
        {
            _permissaoApp = permissaoApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            var lista = _permissaoApp.ListaPermissoes().ToList();
            return View("ListaPerfilAcesso", lista);
        }

        [LogActionFilter]
        public async Task<ActionResult> PerfilAcesso(int? id)
        {
            var perfil = id > 0
                ? _permissaoApp.Perfil(id.Value)
                : new PerfilAcessoFormViewModel
                {
                    PermissoesLista = _permissaoApp.TodasAsPermissoes()
                };
            return View(perfil);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> PerfilAcesso(PerfilAcessoFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception(Erro);
                _permissaoApp.SalvarPerfil(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Alertar(ex.Message);
                return RedirectToAction("PerfilAcesso", new { model.Id });
            }
        }

        [LogActionFilter]
        public async Task<ActionResult> RemovePerfil(int Id)
        {
            var perfil = Id > 0;
            _permissaoApp.DeletePerfil(Id);

            return RedirectToAction("Index", perfil);
        }
    }
}
