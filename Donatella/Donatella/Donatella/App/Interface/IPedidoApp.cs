using Donatella.Models.Enums;
using Donatella.Models.Pedidos;

namespace Donatella.App.Interface
{
    public interface IPedidoApp
    {
        void FecharPedido(FecharPedidoFormViewModel model, int usuarioId);
        BuscaPedidoViewModel Pedidos(int? usuarioId, BuscaPedidoFormViewModel model);
        void MudarStatus(int pedidoId, TipoStatusPedido status);
    }
}