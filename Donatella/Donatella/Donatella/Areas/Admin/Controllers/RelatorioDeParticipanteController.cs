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

    [CustomAuthorize(Permissao = Permissoes.RelatorioUsuarios)]
    public class RelatorioDeParticipanteController : Controller
    {
        private readonly IRelatorioDeParticipanteApp _relatorioDeParticipanteApp;

        public RelatorioDeParticipanteController(IRelatorioDeParticipanteApp relatorioDeParticipanteApp)
        {
            _relatorioDeParticipanteApp = relatorioDeParticipanteApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            return View("RelatorioDeParticipante");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> ListaRelatorioDeParticipante(RelatorioDeParticipanteFormViewModel model)
        {
            var relatorio = _relatorioDeParticipanteApp.RelatorioDeParticipante(model);
            return PartialView(relatorio);
        }

        public void BaixarExcelRelatorioDeParticipante(RelatorioDeParticipanteFormViewModel model)
        {
            var relatorio = _relatorioDeParticipanteApp.RelatorioDeParticipante(model);
            var gv = new GridView { DataSource = relatorio.ToList() };
            gv.DataBind();
            Excel.BaixarExcel(gv, "Relatorio_De_Participante");
        }
    }
}
