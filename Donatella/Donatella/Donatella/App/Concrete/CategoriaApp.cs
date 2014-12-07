using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models.Categorias;
using Donatella.Models.Produtos;

namespace Donatella.App.Concrete
{
    public class CategoriaApp : ICategoriaApp
    {
        private readonly IRepository<Categoria> _categoriaRepository;

        public CategoriaApp(IRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<CategoriaProdutosViewModel> Produtos()
        {
            return (from x in _categoriaRepository.Get()
                where x.DtInativacao == null
                select new CategoriaProdutosViewModel
                {
                    Categoria = x.NomeCategoria,
                    Id = x.Id,
                    Produtos = (from p in x.Produtos
                        where p.DtInativacao == null
                              select new ProdutoViewModel
                              {
                                  Ativo = true,
                                  Categoria = x.NomeCategoria,
                                  Id = p.Id,
                                  Descricao = p.Descricao,
                                  NomeProduto = p.NomeProduto,
                                  Preco = p.Preco,
                                  PrecoDe = p.PrecoDe 
                              })
                    
                });
        }

        public Dictionary<int, string> Combo()
        {
            return (from x in _categoriaRepository.Get()
                    where x.DtInativacao == null
                    orderby x.NomeCategoria
                    select new
                    {
                        x.NomeCategoria,
                        x.Id
                    }).ToDictionary(x => x.Id, x => x.NomeCategoria);
        }

        public Categoria FindByNome(string nome)
        {
            return _categoriaRepository.Get().FirstOrDefault(m => m.NomeCategoria == nome);
        }

        public IEnumerable<Categoria> Categorias()
        {
             return _categoriaRepository.Get(); 
        }

        public CategoriaViewModel Categoria(int id)
        {
            var categoria = _categoriaRepository.Get(id);
            return Mapper.Map<CategoriaViewModel>(categoria);
        }

        public void Salvar(CategoriaViewModel categoria)
        {
            var dbCategoria = categoria.Id == 0 ? new Categoria()
                : _categoriaRepository.Get(categoria.Id);

            if (dbCategoria == null)
                throw new Exception("Categoria não pode ser alterado, pois não existe no banco.");

            dbCategoria.NomeCategoria = categoria.NomeCategoria;

            _categoriaRepository.AddOrUpdate(dbCategoria);
            _categoriaRepository.Commit();
        }

        public void Excluir(int categoriaId)
        {
            var categoria = _categoriaRepository.Get(categoriaId);
            if (categoria == null) throw new Exception("Categoria não existe!");

            if (categoria.Produtos.Any())
                throw new Exception("Categoria não pode ser excluido, pois possui produtos vinculados!");

            _categoriaRepository.Delete(categoria);
            _categoriaRepository.Commit();
        }
    }
}