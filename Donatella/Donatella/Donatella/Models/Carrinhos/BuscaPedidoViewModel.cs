using System.Collections.Generic;

namespace Donatella.Models.Pedidos
{
    public class BuscaPedidoViewModel
    {
        public bool IsAdmin { get; set; }
        public IEnumerable<PedidoViewModel> Pedidos { get; set; }
    }
}