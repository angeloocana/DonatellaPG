using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class PerfilAcessoPermissao : EntityBase
    {
        [ForeignKey("PerfilAcesso")]
        public int PerfilAcessoId { get; set; }
        public virtual PerfilAcesso PerfilAcesso { get; set; }

        public virtual Permissoes Permissao { get; set; }
    }
}