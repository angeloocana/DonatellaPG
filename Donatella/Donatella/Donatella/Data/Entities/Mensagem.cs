using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Donatella.Data.Entities
{
    public class Mensagem : EntityBase
    {
        [ForeignKey("Usuario")]
        public virtual int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        
        public virtual string TxtMensagem { get; set; }

        public virtual DateTime? DtLida { get; set; }
    }
}