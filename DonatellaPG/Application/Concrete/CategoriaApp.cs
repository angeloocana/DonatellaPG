using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;


namespace Application.Concrete
{
    public class EFCategoriaApp : ICategoriaApp
    {
        private EFDbContext _dbContext;

        public EFCategoriaApp()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Categoria> Categorias
        {
            get { return _dbContext.Categorias; }
        }

        public void Salvar(Categoria categoria)
        {
            var dbCategoria = categoria.CategoriaId == 0 ? new Categoria()
                : _dbContext.Categorias.Find(categoria.CategoriaId);

            if (dbCategoria == null)
                throw new Exception("Categoria não pode ser alterada, pois não existe no banco.");

            dbCategoria.Nome = categoria.Nome;

            if (dbCategoria.CategoriaId == 0)
                _dbContext.Categorias.Add(dbCategoria);

            _dbContext.SaveChanges();
        }

        public void Excluir(int categoriaId)
        {
            var categoria = _dbContext.Categorias.Find(categoriaId);
            if (categoria == null) throw new Exception("Categoria não existe!");

            if (categoria.Produtos.Any())
                throw new Exception("Categoria não pode ser excluida, pois possui produtos vinculados!");

            _dbContext.Categorias.Remove(categoria);
            _dbContext.SaveChanges();
        }
    }
}
