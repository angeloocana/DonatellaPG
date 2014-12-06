using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Helpers;
using Donatella.Models.Enums;
using Donatella.Models.Relatorios;

namespace Donatella.App.Concrete
{
    public class LogApp : ILogApp
    {
        private readonly IRepository<Log> _logRepository;

        public LogApp(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        public void SalvarLog(Log log)
        {
            _logRepository.Add(log);
            _logRepository.Commit();
        }

        public IEnumerable<RelatorioDeAcessoViewModel> RelatorioDeAcesso(RelatoriosDeAcessoFormViewModel model)
        {
            var acessos = (from x in _logRepository.Get()
                           where (model.CargoId == null || x.Usuario.CargoId == model.CargoId)
                               && (model.DataInicio == null || x.DtInclusao >= model.DataInicio)
                               && (model.DataFim == null || x.DtInclusao <= model.DataFim)
                               && (model.TipoArea == null || x.Area == model.TipoArea.ToString())
                               && (!string.IsNullOrEmpty(x.Controller))
                           select new
                           {
                               DtAcesso =
                                   model.TipoAcesso == TipoAcesso.PorPagina
                                       ? x.DtInclusao
                                       : DbFunctions.TruncateTime(x.DtInclusao),
                               Pagina = (string.IsNullOrEmpty(x.Area) ? "" : x.Area) + "/" + x.Controller + "/" + x.Action
                           }).Distinct().ToList();

            return from x in acessos
                   group x by new
                   {
                       DtAcesso = model.TipoAcesso == TipoAcesso.PorPagina ? x.DtAcesso.Value.ToString("dd/MM/yyyy") : "",
                       x.Pagina
                   }
                       into g
                       select new RelatorioDeAcessoViewModel
                       {
                           DtAcesso = g.Key.DtAcesso,
                           Pagina = g.Key.Pagina,
                           Quantidade = g.Count()
                       };
        }
    }
}