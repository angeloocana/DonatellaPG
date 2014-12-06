using System;
using Donatella.Helpers;
using Donatella.Models.Enums;

namespace Donatella.Models.Relatorios
{
    public class RelatorioDeAcessoViewModel
    {
        public string Pagina { get; set; }

        public int Quantidade { get; set; }

        public string DtAcesso { get; set; }

        public int? CargoId { get; set; }
    }
}