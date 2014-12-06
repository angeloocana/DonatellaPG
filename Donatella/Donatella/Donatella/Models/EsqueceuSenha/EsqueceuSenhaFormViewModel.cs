using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Donatella.Models
{
    public class EsqueceuSenhaFormViewModel
    {
        [Required, Display(Name = "Digite o seu CPF"), StringLength(14), RegularExpression(@"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)", ErrorMessage = "Cpf inválido.")]
        public string Cpf { get; set; }
    }
}