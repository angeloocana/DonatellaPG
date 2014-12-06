using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donatella.Data.Entities
{
    public class FaqGrupo : EntityBase
    {
        public string Grupo { get; set; }
        public int Ordem { get; set; }
        public virtual ICollection<Faq> Faqs { get; set; }
    }
}