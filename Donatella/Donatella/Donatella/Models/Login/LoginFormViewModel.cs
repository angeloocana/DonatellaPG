using System.ComponentModel.DataAnnotations;

namespace Donatella.Models
{
    public class LoginFormViewModel
    {
        [Required]
        public virtual string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public virtual string Senha { get; set; }
    }
}