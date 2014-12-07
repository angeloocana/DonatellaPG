using System.Collections.Generic;
using Donatella.Models.Produtos;

namespace Donatella.Models.Categorias
{
    public class CategoriaProdutosViewModel
    {
        public int Id { get; set; }
        public string Categoria { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}