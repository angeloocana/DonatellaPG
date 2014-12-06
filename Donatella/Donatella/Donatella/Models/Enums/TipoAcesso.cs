using System.ComponentModel.DataAnnotations;

namespace Donatella.Models.Enums
{
    public enum TipoAcesso
    {
        [Display(Name = "Acessos por página")]
        PorPagina,
        [Display(Name = "Acessos Únicos")]
        Unicos
    }
}
