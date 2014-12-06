using System.Collections.Generic;
using Donatella.Models.Categorias;
using Donatella.Data.Entities;

namespace Donatella.App.Interface
{
    public interface ICategoriaApp
    {
        Dictionary<int, string> Combo();
        Categoria FindByNome(string nome);
        void Salvar(CategoriaViewModel categoria);
        void Excluir(int categoriaId);
        CategoriaViewModel Categoria(int id);
        IEnumerable<Categoria> Categorias();
    }
}