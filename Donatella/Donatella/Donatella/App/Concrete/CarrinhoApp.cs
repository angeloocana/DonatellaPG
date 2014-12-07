using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models.Pedidos;

namespace Donatella.App.Concrete
{
    public class CarrinhoApp : ICarrinhoApp
    {
        private readonly IRepository<Carrinho> _carrinhoRepository;

        public CarrinhoApp(IRepository<Carrinho> carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public void Add(int usuarioId, int produtoId, int qtd)
        {
            var produto = _carrinhoRepository.Get().FirstOrDefault(x => x.UsuarioId == usuarioId
                                                                        && x.ProdutoId == produtoId) ?? new Carrinho
                                                                        {
                                                                            UsuarioId = usuarioId,
                                                                            ProdutoId = produtoId,
                                                                            DtInclusao = DateTime.Now
                                                                        };
            produto.DtAlteracao = DateTime.Now;
            produto.Quantidade = produto.Quantidade + qtd;
            _carrinhoRepository.AddOrUpdate(produto);
            _carrinhoRepository.Commit();
        }

        public void Remove(int usuarioId, int produtoId, int? qtd)
        {
            var produto = _carrinhoRepository.Get().FirstOrDefault(x => x.UsuarioId == usuarioId
                                                                        && x.ProdutoId == produtoId);

            if (produto == null)
                return;

            if (qtd > 0)
            {
                produto.DtAlteracao = DateTime.Now;
                produto.Quantidade = produto.Quantidade - qtd.Value;
                _carrinhoRepository.Update(produto);
            }

            if (qtd == null || produto.Quantidade < 1)
                _carrinhoRepository.Delete(produto);

            _carrinhoRepository.Commit();
        }

        public void Clean(int usuarioId)
        {
            var produtos = _carrinhoRepository.Get().Where(x => x.UsuarioId == usuarioId);
            _carrinhoRepository.DeleteAll(produtos);
            _carrinhoRepository.Commit();
        }

        public CarrinhoViewModel Carrinho(int usuarioId)
        {
            var produtos = from x in _carrinhoRepository.Get()
                           select new CarrinhoProdutoViewModel
                           {
                               Id = x.ProdutoId,
                               Produto = x.Produto.NomeProduto,
                               Preco = x.Produto.Preco,
                               Qtd = x.Quantidade
                           };

            return new CarrinhoViewModel { Produtos = produtos };
        }
    }
}