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
    [CustomAuthorize(Permissao = Permissoes.CadastroUsuario)]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            return View(_usuarioApp.Usuarios());
        }

        [LogActionFilter]
        public async Task<ActionResult> CadastroUsuario(int? id)
        {
            return View(_usuarioApp.Usuario(id));
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<string> CadastroUsuario(UsuarioFormViewModel usuario)
        {
            if (!ModelState.IsValid)
                return Erro;

            try
            {
                _usuarioApp.Salvar(usuario);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [LogActionFilter]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                _usuarioApp.Apagar(id);
                Alertar("Usuário excluído com sucesso.");
            }
            catch (Exception ex)
            {
                Alertar(ex.Message ==
                        "An error occurred while updating the entries. See the inner exception for details."
                    ? "Usuário não pode ser excluído, ele está sendo usado no sistema"
                    : ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
