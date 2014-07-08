using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Concrete
{
    public class ProdutoApp : AppBase, IProdutoApp
    {
        private IRepositoryBase<Produto> _produtoRepositoty;
        public ProdutoApp(IRepositoryBase<Produto> produtoRepositoty)
        {
            _produtoRepositoty = produtoRepositoty;
        }

        public IEnumerable<Produto> Produtos
        {
            get { return _produtoRepositoty.Get(); }
        }

        public void SalvarProduto(Produto produto)
        {
            BeginTransaction();

            var dbProduto = produto.ProdutoId == 0 ? new Produto()
                : _produtoRepositoty.Get(produto.ProdutoId);

            if (dbProduto == null)
                throw new Exception("Produto não pode ser alterado, pois não existe no banco.");

            dbProduto.Adicional = produto.Adicional;
            dbProduto.Categoria = produto.Categoria;
            dbProduto.Nome = produto.Nome;
            dbProduto.Preco = produto.Preco;
            dbProduto.PrecoDe = produto.PrecoDe;
            
            if (dbProduto.ProdutoId == 0)
                _produtoRepositoty.Add(dbProduto);

            Commint();
        }
    }
}
