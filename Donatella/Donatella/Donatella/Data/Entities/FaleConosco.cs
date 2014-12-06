using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donatella.Data.Entities
{
    public class FaleConosco : EntityBase
    {

        [ForeignKey("Usuario")]
        public virtual int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        
        [Required]
        public virtual string Nome { get; set; }

        [EmailAddress, Required]
        public virtual string Email { get; set; }

        [Required]
        public virtual string Cpf { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string Cnpj { get; set; }

        [Required]
        public virtual string Assunto { get; set; }

        [Required]
        public virtual string Mensagem { get; set; }
    }
}