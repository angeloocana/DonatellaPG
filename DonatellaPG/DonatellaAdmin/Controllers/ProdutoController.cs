using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonatellaAdmin.infrastructure;
using DonatellaAdmin.Models.Produtos;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaAdmin.Controllers
{
    [CustomAuthorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ActionResult Index()
        {
            return View("Produtos", _produtoRepository.Produtos);
        }
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            var produto = id > 0 ? _produtoRepository.Produtos.FirstOrDefault(c => c.ProdutoId == id)
                : new Produto();

            if (produto != null)
            {
                var frmProduto = new ProdutoFormViewModel
                {
                    Adicional = produto.Adicional,
                    Categoria = produto.CategoriaId,
                    Disponivel = produto.Disponivel,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    PrecoDe = produto.PrecoDe,
                    ProdutoId = produto.ProdutoId
                };
                return View("Produto", frmProduto);
            }

            TempData["Alerta"] = "Produto não encontrado!";
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (!ModelState.IsValid)
                return View("Produto", produto);

            try
            {
                //_produtoRepository.Salvar(produto);
            }
            catch (Exception ex)
            {
                TempData["Alerta"] = ex.Message;
                return View("Produto", produto);
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Excluir(int id)
        {
            try
            {
                _produtoRepository.Excluir(id);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}