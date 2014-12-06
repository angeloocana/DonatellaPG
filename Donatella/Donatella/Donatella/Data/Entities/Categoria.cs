using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class Categoria : EntityBase
    {
        [StringLength(150)]
        public virtual string NomeCategoria { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; } 
    }
}
