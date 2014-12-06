using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Donatella.Models
{
    public class TrocaSenhaFormViewModel
    {
        [HiddenInput]
        public string TokenSenha { get; set; }

        [Required, Display(Name = "Digite o seu CPF"), StringLength(14), RegularExpression(@"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)", ErrorMessage = "Cpf inválido.")]
        public string Cpf { get; set; }

        [Required, DataType(DataType.Password)]
        public string NovaSenha { get; set; }

        [Display(Name = "Confirma Senha"), DataType(DataType.Password), System.Web.Mvc.CompareAttribute("NovaSenha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmaSenha { get; set; }
    }
}