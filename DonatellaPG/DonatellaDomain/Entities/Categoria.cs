using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Categoria
    {
        [Key]
        public virtual int CategoriaId { get; set; }
        public virtual string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; } 
    }
}
