using System.Collections.Generic;
using System.Linq;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IPedidoApp
    {
        IEnumerable<Pedido> Pedidos { get; }
        void SalvarPedido(Pedido pedido);
    }
}