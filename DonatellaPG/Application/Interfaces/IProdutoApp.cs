using System.Collections.Generic;
using System.Linq;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IProdutoApp
    {
        IEnumerable<Produto> Produtos { get; }
        void SalvarProduto(Produto produto);
    }
}