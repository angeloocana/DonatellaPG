using System.ComponentModel.DataAnnotations;

namespace Donatella.Models.Enums
{
    public enum TipoStatusPedido
    {
        [Display(Name = "Criado", GroupName = "warning")]
        Criado,
        [Display(Name = "Produzindo", GroupName = "danger")]
        Produzindo,
        [Display(Name = "Saiu para entrega", GroupName = "info")]
        SaiuParaEntrega,
        [Display(Name = "Entregue", GroupName = "success")]
        Entregue,
        [Display(Name = "Cancelado", GroupName = "primary")]
        Cancelado
    }
}