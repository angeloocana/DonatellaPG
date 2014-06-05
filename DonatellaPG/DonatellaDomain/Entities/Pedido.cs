using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Pedido
    {
        [Key]
        public virtual int PedidoId { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual decimal ValorTotal { get; set; }
        public virtual FormaDePagamento FormaDePagamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual int Mesa { get; set; }
        public virtual StatusPedido Status { get; set; }
        public virtual int NotaAvaliacao { get; set; }
    }
}
