namespace Donatella.Models.Pedidos
{
    public class CarrinhoProdutoViewModel
    {
        public string Produto { get; set; }
        public int Id { get; set; }
        public int Qtd { get; set; }
        public decimal Preco { get; set; }
        public decimal Total { get { return Qtd * Preco; } }
    }
}