using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models.Enums;
using Donatella.Models.Pedidos;

namespace Donatella.App.Concrete
{
    public class PedidoApp : IPedidoApp
    {
        private readonly IRepository<Pedido> _pedidoRepository;
        private readonly IRepository<PedidoProduto> _pedidoProdutoRepository;
        private readonly ICarrinhoApp _carrinhoApp;

        public PedidoApp(IRepository<Pedido> pedidoRepository, IRepository<PedidoProduto> pedidoProdutoRepository,
            ICarrinhoApp carrinhoApp)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoProdutoRepository = pedidoProdutoRepository;
            _carrinhoApp = carrinhoApp;
        }

        public void FecharPedido(FecharPedidoFormViewModel model, int usuarioId)
        {
            var carrinho = _carrinhoApp.Carrinho(usuarioId);
            if (carrinho == null || carrinho.Produtos == null || !carrinho.Produtos.Any())
                throw new Exception("O carrinho está vazio!");

            var pedido = Mapper.Map<Pedido>(model);
            pedido.DtInclusao = DateTime.Now;
            pedido.StatusPedido = TipoStatusPedido.Criado;
            pedido.UsuarioId = usuarioId;

            _pedidoRepository.Add(pedido);
            _pedidoRepository.Commit();

            foreach (var produto in carrinho.Produtos)
            {
                var pedidoProduto = new PedidoProduto
                {
                    DtInclusao = DateTime.Now,
                    PedidoId = pedido.Id,
                    ProdutoId = produto.Id,
                    Quantidade = produto.Qtd,
                    ValorUnitario = produto.Preco
                };
                _pedidoProdutoRepository.Add(pedidoProduto);
            }
            _pedidoRepository.Commit();
        }

        public BuscaPedidoViewModel Pedidos(int? usuarioId, BuscaPedidoFormViewModel model)
        {
            var pedidos = (from x in _pedidoRepository.Get()
                           where
                           (usuarioId == null || x.UsuarioId == usuarioId)
                          && (model.Status == null || x.StatusPedido == model.Status)
                           orderby x.DtInclusao descending
                           select new PedidoViewModel
                           {
                               DtInclusao = x.DtInclusao,
                               Status = x.StatusPedido,
                               FormaDePagamento = x.FormaDePagamento.NomeFormaDePagamento,
                               Produtos = x.Produtos.Select(p => new CarrinhoProdutoViewModel
                               {
                                   Id = p.Id,
                                   Preco = p.ValorUnitario,
                                   Produto = p.Produto.NomeProduto,
                                   Qtd = p.Quantidade
                               }),
                               Bairro = x.Bairro,
                               Celular = x.Celular,
                               Cep = x.Cep,
                               Cidade = x.Cidade,
                               Complemento = x.Complemento,
                               Cpf = x.Cpf,
                               Email = x.Usuario.Email,
                               Logradouro = x.Logradouro,
                               Nome = x.Usuario.Nome,
                               Numero = x.Numero,
                               Telefone = x.Telefone,
                               TemCpfNaNota = x.TemCpfNaNota,
                               Uf = x.Uf,
                               Id = x.Id
                           });

            return new BuscaPedidoViewModel
            {
                Pedidos = pedidos,
                IsAdmin = model.IsAdmin
            };
        }

        public void MudarStatus(int pedidoId, TipoStatusPedido status)
        {
            var pedido = _pedidoRepository.Get(pedidoId);
            pedido.StatusPedido = status;
            _pedidoRepository.Update(pedido);
            _pedidoRepository.Commit();
        }
    }
}