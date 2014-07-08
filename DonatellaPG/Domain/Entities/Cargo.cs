using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cargo
    {
        [Key]
        public virtual int CargoId { get; set; }

        [StringLength(150)]
        //[Required(ErrorMessage = "Campo obrigatório!")]
        [DisplayName("Cargo")]
        public virtual string NomeCargo { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }

    }
}
