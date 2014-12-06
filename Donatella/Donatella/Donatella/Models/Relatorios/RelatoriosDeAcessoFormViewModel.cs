using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Donatella.Helpers;
using Donatella.Models.Enums;

namespace Donatella.Models.Relatorios
{
    public class RelatoriosDeAcessoFormViewModel
    {
        [Display(Name = "Cargo")]
        [DataType("CargoId")]
        public int? CargoId { get; set; }

        public DateTime? DtAcesso { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        [DataType("TipoAcesso")]
        public TipoAcesso? TipoAcesso { get; set; }

        [DataType("TipoArea")]
        public TipoArea? TipoArea { get; set; }
    }

    public class GridRelatorioDeAcessosViewModel
    {
        public IEnumerable<RelatorioDeAcessoViewModel> Relatorio { get; set; }
        public TipoAcesso TipoAcesso { get; set; }
    }
}


