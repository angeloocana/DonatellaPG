using System;
using System.ComponentModel.DataAnnotations;
using Donatella.Helpers;
using Donatella.Models.Enums;

namespace Donatella.Models.Relatorios
{
    public class RelatorioDeParticipanteFormViewModel
    {
        [Display(Name = "Cargo")]
        [DataType("CargoId")]
        public int? CargoId { get; set; }

        [Display(Name = "Estado")]
        [DataType("Uf")]
        public Uf? Uf { get; set; }

        [Display(Name = "Sexo")]
        [DataType("Sexo")]
        public Sexo? Sexo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DtNascimento { get; set; }
        public Int64? Cpf { get; set; }
    }
}