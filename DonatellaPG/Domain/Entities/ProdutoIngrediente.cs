using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProdutoIngrediente
    {
        [Key]
        public virtual int ProdutoIngredienteId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        [Required]
        public virtual decimal Quantidade { get; set; }
    }
}
