using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Donatella.Data.Entities
{
    public class StatusPedido : EntityBase
    {
        [StringLength(50)]
        [Required]
        public virtual string Status { get; set; }
    }
}
