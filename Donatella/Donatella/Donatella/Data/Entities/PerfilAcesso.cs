using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class PerfilAcesso : EntityBase
    {
        public string Perfil { get; set; }
        public virtual ICollection<PerfilAcessoPermissao> Permissoes { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}