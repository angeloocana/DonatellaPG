using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models;
using Donatella.Models.Enums;

namespace Donatella.Controllers
{
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
            var model = _usuarioApp.Usuarios();
            return View("Usuarios", model);
        }

        [LogActionFilter]
        public async Task<ActionResult> Editar(int? id)
        {
            var model = id == null ? new UsuarioFormViewModel() : _usuarioApp.Usuario(id.Value);
            return View("Usuario", model);
        }

        [LogActionFilter]
        public async Task<ActionResult> PrimeiroAcesso()
        {
            var model = new UsuarioFormViewModel
            {
                TipoTelaDeUsuario = TipoTelaDeUsuario.PrimeiroAcesso
            };
            return View("Usuario", model);
        }

        [LogActionFilter]
        public async Task<ActionResult> MeusDados()
        {
            var model = _usuarioApp.Usuario(UsuarioLogado.CurrentUser.UserId);
            model.TipoTelaDeUsuario = TipoTelaDeUsuario.MeusDados;
            return View("Usuario", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Editar(UsuarioFormViewModel model)
        {
            try
            {
                if (model.TipoTelaDeUsuario == TipoTelaDeUsuario.MeusDados)
                {
                    _usuarioApp.ValidarSenha(UsuarioLogado.CurrentUser.UserId, model.SenhaAtual);

                    ModelState.Remove("NovaSenha");
                    ModelState.Remove("ConfirmaSenha");
                }
                else if (model.TipoTelaDeUsuario == TipoTelaDeUsuario.PrimeiroAcesso || model.TipoTelaDeUsuario == TipoTelaDeUsuario.Admin)
                {
                    ModelState.Remove("SenhaAtual");
                }

                if (!ModelState.IsValid)
                    throw new Exception(Erro);

                _usuarioApp.Salvar(model);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("Usuario", model);
            }

            switch (model.TipoTelaDeUsuario)
            {
                case TipoTelaDeUsuario.Admin: return RedirectToAction("Index");
                case TipoTelaDeUsuario.MeusDados:
                    return RedirectToAction("Index", "Home");
                case TipoTelaDeUsuario.PrimeiroAcesso:
                    return RedirectToAction("Index", "Login");
                default:
                    return RedirectToAction("Index", "Login");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
                _usuarioApp.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
