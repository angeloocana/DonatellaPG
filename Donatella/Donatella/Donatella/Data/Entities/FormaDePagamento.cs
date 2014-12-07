using System.Collections.Generic;

namespace Donatella.Data.Entities
{
    public class FormaDePagamento : EntityBase
    {
        public virtual string NomeFormaDePagamento { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
