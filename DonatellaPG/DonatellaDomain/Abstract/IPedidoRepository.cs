using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface IPedidoRepository
    {
        IQueryable<Pedido> Pedidos { get; }
        void SalvarPedido(Pedido pedido);
    }
}