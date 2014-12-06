using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class UsuarioPerfilAcesso : EntityBase
    {
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("PerfilAcesso")]
        public int PerfilAcessoId { get; set; }
        public virtual PerfilAcesso PerfilAcesso { get; set; }
    }
}