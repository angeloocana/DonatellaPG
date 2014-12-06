using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models
{
    public class FaqGrupoViewModel : IMapFrom<Donatella.Data.Entities.FaqGrupo>
    {
        public virtual int Id { get; set; }
        public virtual string Grupo { get; set; }
        public virtual IEnumerable<FaqViewModel> Faqs { get; set; }
        public virtual int Ordem { get; set; }

    }
    public class FaqGrupoFormViewModel : IMapFrom<FaqGrupo>
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public virtual string Grupo { get; set; }
        [Required]
        public virtual int Ordem { get; set; }
        [HiddenInput]
        public virtual ICollection<Faq> Faqs { get; set; }
    }
}