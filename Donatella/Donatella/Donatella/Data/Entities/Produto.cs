using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class Produto : EntityBase
    {
        [StringLength(150)]
        [Required]
        public virtual string NomeProduto { get; set; }

        public string Descricao { get; set; }

        [Display(Name = "Preço De")]
        public virtual decimal? PrecoDe { get; set; }

        [Required]
        public virtual decimal Preco { get; set; }

        [ForeignKey("Categoria")]
        public virtual int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
