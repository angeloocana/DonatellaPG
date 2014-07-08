using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaptchaMvc.Attributes;
using DonatellaAdmin.Models;
using Application.Interfaces;
using Domain.Entities;
using Newtonsoft.Json;

namespace DonatellaAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IFuncionarioApp _funcionarioApp;

        public LoginController(IFuncionarioApp funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;
        }

        public ActionResult Index()
        {
            return View("Login");
        }

        [CaptchaVerify("Captcha inválida.")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Logar(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Login", model);

            try
            {
                var funcionario = _funcionarioApp.ValidarLogin(model.CPF, model.Senha);
                if (funcionario == null || !funcionario.Ativo)
                    throw new Exception("Login e senha inválidos!");

                var serializeModel = new CustomPrincipalSerializeModel()
                {
                    FirstName = funcionario.NomeFuncionario,
                    LastName = funcionario.Email,
                    Roles = funcionario.Permissoes.Select(p => p.Permissao.ToString()).ToArray(),
                    UserId = funcionario.FuncionarioId
                };

                var userData = JsonConvert.SerializeObject(serializeModel);
                var authTicket = new FormsAuthenticationTicket(
                1,
                funcionario.CPF,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false, //pass here true, if you want to implement remember me functionality
                userData);

                var encTicket = FormsAuthentication.Encrypt(authTicket);
                var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
            }

            return View("Login", model);
        }

        [Authorize]
        public ActionResult Sair()
        {
            try
            {
                FormsAuthentication.SignOut();
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}