using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class PedidoProduto : EntityBase
    {
        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        [Required]
        public virtual int Quantidade { get; set; }
        [Required]
        public virtual decimal ValorUnitario { get; set; }
        [StringLength(250)]
        public virtual string Obs { get; set; }
    }
}
