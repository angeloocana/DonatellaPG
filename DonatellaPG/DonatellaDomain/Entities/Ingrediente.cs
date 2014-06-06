using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Ingrediente
    {
        [Key]
        public virtual int IngredienteId { get; set; }
        [StringLength(150)]
        [Required]
        public virtual string NomeIngrediente { get; set; }
    }
}
