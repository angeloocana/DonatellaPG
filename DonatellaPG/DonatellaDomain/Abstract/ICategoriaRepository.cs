using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface ICategoriaRepository
    {
        IQueryable<Categoria> Categorias { get; }
        void Salvar(Categoria categoria);

        void Excluir(int categoriaId);
    }
}