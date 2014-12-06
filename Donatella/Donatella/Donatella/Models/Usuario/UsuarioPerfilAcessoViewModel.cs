using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Data.Entities;

namespace Donatella.Models
{
    public class UsuarioPerfilAcessoViewModel
    {
        public PerfilAcesso PerfilAcesso { get; set; }
        public bool Possui { get; set; }
    }
}