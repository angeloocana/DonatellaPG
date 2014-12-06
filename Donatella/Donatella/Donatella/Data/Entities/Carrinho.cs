using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class Carrinho : EntityBase
    {
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public virtual int Quantidade { get; set; }

        [StringLength(250)]
        public virtual string Obs { get; set; }
    }
}
