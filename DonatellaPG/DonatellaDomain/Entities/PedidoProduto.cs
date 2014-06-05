using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class PedidoProduto
    {
        [Key]
        public virtual int PedidoProdutoId { get; set; }
        /// <summary>
        /// Se for acompanhamento marcar o produto pai, ex: adicional de bacon na pizza x
        /// </summary>
        public virtual PedidoProduto PedidoProdutoPai { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual decimal ValorUnitario { get; set; }
        public virtual string Obs { get; set; }
    }
}
