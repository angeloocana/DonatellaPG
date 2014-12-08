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
