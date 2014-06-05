using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Estoque
    {
        [Key]
        public virtual int EstoqueId { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public virtual decimal Quantidade { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual string Obs { get; set; }
    }
}
