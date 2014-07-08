using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class IngredienteFornecedor
    {
        [Key]
        public virtual int IngredienteFornecedorId { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        
        public virtual Fornecedor Fornecedor { get; set; }
        [Required]
        public virtual DateTime DataInclusao { get; set; }
    }
}
