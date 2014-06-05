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
        public virtual string Status { get; set; }
    }
}
