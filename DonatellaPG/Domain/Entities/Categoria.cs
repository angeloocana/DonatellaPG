using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Categoria
    {
        [Key]
        public virtual int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(150)]
        [DisplayName("Categoria")]
        public virtual string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; } 
    }
}
