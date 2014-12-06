using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;

namespace Donatella.Data.Entities
{

    public class Log : EntityBase
    {
        [ForeignKey("LogPai")]
        public virtual int? LogIdPai { get; set; }

        public virtual Log LogPai { get; set; }

        [ForeignKey("Usuario")]
        public virtual int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual string Action { get; set; }

        public virtual string Controller { get; set; }

        public virtual string Ip { get; set; }

        public virtual string Area { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }

}