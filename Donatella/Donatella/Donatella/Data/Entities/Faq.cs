using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donatella.Data.Entities
{
    public class Faq : EntityBase
    {
        [Required]
        public string Pergunta { get; set; }
        [Required]
        public string Resposta { get; set; }
        public int Ordem { get; set; }

        [ForeignKey("FaqGrupo")]
        public int FaqGrupoId { get; set; }
        public virtual FaqGrupo FaqGrupo { get; set; }
    }
}