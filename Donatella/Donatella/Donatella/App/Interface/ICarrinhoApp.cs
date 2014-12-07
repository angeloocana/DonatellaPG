using Donatella.Models.Pedidos;

namespace Donatella.App.Interface
{
    public interface ICarrinhoApp
    {
        void Add(int usuarioId, int produtoId, int qtd);

        void Remove(int usuarioId, int produtoId, int? qtd);

        void Clean(int usuarioId);

        CarrinhoViewModel Carrinho(int usuarioId);
    }
}