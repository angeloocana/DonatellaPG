using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class Pedido : EntityBase
    {
        [Required]
        public virtual DateTime Data { get; set; }
        [Required]
        public virtual decimal ValorTotal { get; set; }

        [ForeignKey("FormaDePagamento")]
        public int FormaDePagamentoId { get; set; }
        public virtual FormaDePagamento FormaDePagamento { get; set; }
        
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required]
        [ForeignKey("StatusPedido")]
        public int StatusPedidoId { get; set; }
        public virtual StatusPedido StatusPedido { get; set; }

        public virtual int? NotaAvaliacao { get; set; }
    }
}
