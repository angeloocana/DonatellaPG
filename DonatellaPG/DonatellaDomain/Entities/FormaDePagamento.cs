using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class FormaDePagamento
    {
        [Key]
        public virtual int FormaDePagamentoId { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool Ativo { get; set; }
    }
}
