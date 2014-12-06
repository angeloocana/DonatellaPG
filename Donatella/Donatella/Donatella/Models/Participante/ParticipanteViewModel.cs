using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Donatella.Models
{
    public class ParticipanteViewModel
    {
        [Required, HiddenInput]
        public int ParticipanteId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}