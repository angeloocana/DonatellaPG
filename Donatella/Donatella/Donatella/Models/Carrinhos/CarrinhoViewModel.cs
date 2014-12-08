using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatella.Models.Pedidos
{
    public class CarrinhoViewModel
    {
        public decimal TaxaDeEntrega { get { return 10; } }
        public decimal Total
        {
            get { return Produtos.Select(x => x.Total).Sum() + TaxaDeEntrega; }
        }

        public IEnumerable<CarrinhoProdutoViewModel> Produtos { get; set; }
    }
}