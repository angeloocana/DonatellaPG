using System.Collections.Generic;
using Donatella.Data.Entities;
using Donatella.Models.Relatorios;

namespace Donatella.App.Interface
{
    public interface IRelatorioDeParticipanteApp
    {

        IEnumerable<RelatorioDeParticipanteViewModel> RelatorioDeParticipante(RelatorioDeParticipanteFormViewModel model);
    }
}