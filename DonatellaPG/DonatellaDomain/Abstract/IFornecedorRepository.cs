using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface IFornecedorRepository
    {
        IQueryable<Fornecedor> Fornecedores { get; }
        void SalvarFornecedor(Fornecedor fornecedor);
    }
}