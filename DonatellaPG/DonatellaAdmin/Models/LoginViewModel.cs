using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonatellaAdmin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login é obrigatorio!")]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Senha é obrigatorio!")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}