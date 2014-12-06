using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models;
using Donatella.Models.Enums;
using Newtonsoft.Json;

namespace Donatella.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly ILogApp _logApp;
        public LoginController(IUsuarioApp usuarioApp, ILogApp logApp)
        {
            _usuarioApp = usuarioApp;
            _logApp = logApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            if (UsuarioLogado.Logado)
            {
                Deslogar();
                return RedirectToAction("Index");
            }
            return View("Login");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                Logar(_usuarioApp, _logApp, model, TipoArea.Site);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);
                return View(model);
            }
        }

        [LogActionFilter]
        public async Task<ActionResult> Logout()
        {
            Deslogar();
            return RedirectToAction("Index", "Login");
        }

        private void Logar(IUsuarioApp usuarioApp, ILogApp logApp, LoginFormViewModel model, TipoArea area)
        {
            if (!ModelState.IsValid)
                throw new Exception(Erro);

            var usuario = usuarioApp.ValidarLogin(model, area);

            var log = new Log()
            {
                Action = "Login",
                Controller = "Login",
                UsuarioId = usuario.UserId,
                Ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"],
                Area = area.ToString()
            };
            logApp.SalvarLog(log);
            usuario.LogId = log.Id;

            var userData = JsonConvert.SerializeObject(usuario);
            var authTicket = new FormsAuthenticationTicket(1, usuario.UserId.ToString(), DateTime.Now,
                DateTime.Now.AddMinutes(30), false, userData);
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
        }

        private void Deslogar()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
        }
    }
}
