using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models.Produtos;

namespace Donatella.App.Concrete
{
    public class ProdutoApp : IProdutoApp
    {
        private readonly IRepository<Produto> _produtoRepository;

        public ProdutoApp(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

       public IQueryable<ProdutoViewModel> Produtos()
       {
           return _produtoRepository.Get().Project().To<ProdutoViewModel>();
       }

        public ProdutoFormViewModel Produto(int id)
        {
            var produto = _produtoRepository.Get(id);
            return Mapper.Map<ProdutoFormViewModel>(produto);
        }

        public void Salvar(ProdutoFormViewModel produto)
        {
            var dbProduto = produto.Id == 0 ? Mapper.Map<ProdutoFormViewModel, Produto>(produto)
                : _produtoRepository.Get(produto.Id);

            if (dbProduto == null)
                throw new Exception("Produto não pode ser alterado, pois não existe no banco.");

            if (dbProduto.Id > 0)
                dbProduto = Mapper.Map(produto, dbProduto);

            _produtoRepository.AddOrUpdate(dbProduto);
            _produtoRepository.Commit();
        }

        public void Excluir(int produtoId)
        {
            var produto = _produtoRepository.Get(produtoId);
            if (produto == null) throw new Exception("Produto não existe!");
            
            _produtoRepository.Delete(produto);
            _produtoRepository.Commit();
        }
    }
}