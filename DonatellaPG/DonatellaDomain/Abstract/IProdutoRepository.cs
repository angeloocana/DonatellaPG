using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> Produtos { get; }
        void SalvarProduto(Produto produto);

        void Excluir(int produtoId);
    }
}