using System.ComponentModel.DataAnnotations;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models
{
    public class FaleConoscoFormViewModel : IMapFrom<FaleConosco>
    {
        [Required]
        public virtual string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public virtual string Email { get; set; }

        [Required]
        [StringLength(14), RegularExpression(@"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)", ErrorMessage = "CPF inválido")]
        public virtual string Cpf { get; set; }

        [Required]
        [MaxLength(14)]
        public virtual string Telefone { get; set; }
        
        [Required]
        [DataType("Assunto")]
        public virtual string Assunto { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Mensagem { get; set; }
    }
}