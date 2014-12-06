using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Models.Enums;

namespace Donatella.Models
{
    public class PermissaoViewModel
    {
        public Permissoes Permissao { get; set; }
        public bool Possui { get; set; }
    }
}