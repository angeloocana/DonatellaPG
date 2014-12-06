using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models.Enums;
using Donatella.Models.Relatorios;


namespace Donatella.Areas.Admin.Controllers
{
    [CustomAuthorize(Permissao = Permissoes.RelatorioAcesso)]
    public class RelatorioDeAcessoController : Controller
    {
        private readonly ILogApp _logApp;

        public RelatorioDeAcessoController(ILogApp logApp)
        {
            _logApp = logApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            return View("RelatorioDeAcesso");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> ListaRelatorioDeAcesso(RelatoriosDeAcessoFormViewModel model)
        {
            if (model.TipoAcesso == null)
                model.TipoAcesso = TipoAcesso.Unicos;

            var relatorio = new GridRelatorioDeAcessosViewModel
            {
                Relatorio = _logApp.RelatorioDeAcesso(model),
                TipoAcesso = model.TipoAcesso.Value
            };
            return PartialView("ListaRelatorioDeAcesso", relatorio);
        }

        public void BaixarExcelRelatorioDeAcesso(RelatoriosDeAcessoFormViewModel model)
        {
            var relatorio = _logApp.RelatorioDeAcesso(model);
            var gv = new GridView { DataSource = relatorio.ToList() };
            gv.DataBind();
            Excel.BaixarExcel(gv, "Relatorio_De_Acesso");
        }
    }
}
