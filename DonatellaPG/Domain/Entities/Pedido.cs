using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Pedido
    {
        [Key]
        public virtual int PedidoId { get; set; }
        [Required]
        public virtual DateTime Data { get; set; }
        [Required]
        public virtual decimal ValorTotal { get; set; }
        public virtual FormaDePagamento FormaDePagamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual int? Mesa { get; set; }
        [Required]
        public virtual StatusPedido Status { get; set; }
        public virtual int? NotaAvaliacao { get; set; }
    }
}
