using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Models.Enums;

namespace Donatella.Models.Pedidos
{
    public class BuscaPedidoFormViewModel
    {
        [HiddenInput]
        public bool IsAdmin { get; set; }

        [Required, DataType("StatusPedido")]
        public TipoStatusPedido? Status { get; set; }
    }
}