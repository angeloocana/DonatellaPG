using System.Collections.Generic;
using System.Linq;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IFornecedorApp
    {
        IEnumerable<Fornecedor> Fornecedores { get; }
        void SalvarFornecedor(Fornecedor fornecedor);
    }
}