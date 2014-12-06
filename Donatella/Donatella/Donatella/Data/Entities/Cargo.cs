using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class Cargo : EntityBase
    {
        [StringLength(150)]
        public virtual string NomeCargo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
