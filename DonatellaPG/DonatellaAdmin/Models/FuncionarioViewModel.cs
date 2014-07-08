using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace DonatellaAdmin.Models
{
    public class FuncionarioViewModel
    {
        public Funcionario Funcionario { get; set; }
        
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public IEnumerable<Permissao> Permissoes { get; set; }

        public IEnumerable<SelectListItem> Cargos { get; set; } 
    }
}