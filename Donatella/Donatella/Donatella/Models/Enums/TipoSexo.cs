using System.ComponentModel.DataAnnotations;

namespace Donatella.Models.Enums
{
    public enum Sexo
    {
        [Display(Name = "Masculino")]
        M,
        [Display(Name = "Feminino")]
        F
    }
}