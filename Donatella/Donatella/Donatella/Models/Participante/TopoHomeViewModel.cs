using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatella.Models
{
    public class TopoHomeViewModel
    {
        public DateTime? DtUltimaAlteracao { get; set; }
        public virtual string Nome { get; set; }

        public virtual string Foto { get; set; }
        public virtual decimal Saldo { get; set; }

    }
}