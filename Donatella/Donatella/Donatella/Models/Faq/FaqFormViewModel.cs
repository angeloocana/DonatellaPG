using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models
{
    public class FaqViewModel : IMapFrom<Donatella.Data.Entities.Faq>
    {
        public virtual int Id { get; set; }
        public virtual string Pergunta { get; set; }
        public virtual string Resposta { get; set; }
        public virtual int Ordem { get; set; }
        public virtual string FaqGrupo { get; set; }
    }

    public class FaqFormViewModel : IMapFrom<Donatella.Data.Entities.Faq>
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public virtual string Pergunta { get; set; }
        [Required]
        public virtual string Resposta { get; set; }
        public virtual int Ordem { get; set; }

        [Required, DataType("FaqGrupoId"), Display(Name = "Faq Grupo")]
        public virtual int FaqGrupoId { get; set; }
    }
}