using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models.Enums;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class MeusDadosController : BaseController
    {
        private readonly IParticipanteApp _participanteApp;

        public MeusDadosController(IParticipanteApp participanteApp)
        {
            _participanteApp = participanteApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            var cadastro = _participanteApp.Cadastro(UsuarioLogado.CurrentUser.UserId);
            cadastro.TipoTelaDeCadastro = TipoTelaDeCadastro.MeusDados;
            return View("MeusDados", cadastro);
        }
    }
}
