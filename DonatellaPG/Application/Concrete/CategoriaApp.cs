using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Concrete
{
    public class CategoriaApp : AppBase, ICategoriaApp
    {
        private IRepositoryBase<Categoria> _categoriaRepository;
        public CategoriaApp(IRepositoryBase<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public IEnumerable<Categoria> Categorias
        {
            get { return _categoriaRepository.Get(); }
        }

        public void Salvar(Categoria categoria)
        {
            BeginTransaction();

            var dbCategoria = categoria.CategoriaId == 0 ? new Categoria()
                : _categoriaRepository.Get(categoria.CategoriaId);

            if (dbCategoria == null)
                throw new Exception("Categoria não pode ser alterada, pois não existe no banco.");

            dbCategoria.Nome = categoria.Nome;

            if (dbCategoria.CategoriaId == 0)
                _categoriaRepository.Add(dbCategoria);

            Commint();
        }

        public void Excluir(int categoriaId)
        {
            var categoria = _categoriaRepository.Get(categoriaId);
            if (categoria == null) throw new Exception("Categoria não existe!");

            if (categoria.Produtos.Any())
                throw new Exception("Categoria não pode ser excluida, pois possui produtos vinculados!");

            BeginTransaction();
            _categoriaRepository.Delete(categoria);
            Commint();
        }
    }
}
