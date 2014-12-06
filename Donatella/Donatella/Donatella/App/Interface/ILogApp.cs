using System.Collections.Generic;
using Donatella.Data.Entities;
using Donatella.Models.Enums;
using Donatella.Models.Relatorios;

namespace Donatella.App.Interface
{
    public interface ILogApp
    {
        void SalvarLog(Log log);
        IEnumerable<RelatorioDeAcessoViewModel> RelatorioDeAcesso(RelatoriosDeAcessoFormViewModel model);
    }
}
