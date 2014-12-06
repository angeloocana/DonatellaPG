using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFProdutoRepository : IProdutoRepository
    {
        private EFDbContext _dbContext;
        public EFProdutoRepository()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Produto> Produtos
        {
            get { return _dbContext.Produtos; }
        }

        public void SalvarProduto(Produto produto)
        {
            var dbProduto = produto.ProdutoId == 0 ? new Produto()
                : _dbContext.Produtos.Find(produto.ProdutoId);

            if (dbProduto == null)
                throw new Exception("Produto não pode ser alterado, pois não existe no banco.");

            dbProduto.Adicional = produto.Adicional;
            dbProduto.Categoria = produto.Categoria;
            dbProduto.Nome = produto.Nome;
            dbProduto.Preco = produto.Preco;
            dbProduto.PrecoDe = produto.PrecoDe;
            
            if (dbProduto.ProdutoId == 0)
                _dbContext.Produtos.Add(dbProduto);

            _dbContext.SaveChanges();
        }


        public void Excluir(int produtoId)
        {
            var produto = _dbContext.Produtos.Find(produtoId);
            if (produto == null) throw new Exception("Produto não existe!");

            _dbContext.Produtos.Remove(produto);
            _dbContext.SaveChanges();
        }
    }
}
