using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class StatusPedido
    {
        public virtual int StatusPedidoId { get; set; }
        [StringLength(50)]
        [Required]
        public virtual string Status { get; set; }
    }
}
