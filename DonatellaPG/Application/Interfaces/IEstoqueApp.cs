using System.Collections.Generic;
using System.Linq;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IEstoqueApp
    {
        IEnumerable<Estoque> Estoques { get; }
        void SalvarEstoque(Estoque estoque);
    }
}