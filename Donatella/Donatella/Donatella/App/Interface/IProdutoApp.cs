using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Models;
using Donatella.Models.Produtos;
using Donatella.Models.Enums;
using Donatella.Data.Entities;

namespace Donatella.App.Interface
{
    public interface IProdutoApp
    {
        void Salvar(ProdutoFormViewModel produto);
        void Excluir(int produtoId);
        ProdutoFormViewModel Produto(int id);
        IQueryable<ProdutoViewModel> Produtos();
    }
}