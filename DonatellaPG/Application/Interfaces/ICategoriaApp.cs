using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICategoriaApp
    {
        IEnumerable<Categoria> Categorias { get; }
        void Salvar(Categoria categoria);

        void Excluir(int categoriaId);
    }
}