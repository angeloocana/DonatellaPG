using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface IEstoqueRepository
    {
        IQueryable<Estoque> Estoques { get; }
        void SalvarEstoque(Estoque estoque);
    }
}