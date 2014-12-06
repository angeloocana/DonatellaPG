using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class FormaDePagamento : EntityBase
    {
        public virtual string Descricao { get; set; }
        public virtual bool Ativo { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
