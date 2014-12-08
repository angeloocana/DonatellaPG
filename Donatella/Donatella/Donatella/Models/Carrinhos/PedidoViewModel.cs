using System;
using System.ComponentModel.DataAnnotations;
using Donatella.Models.Enums;

namespace Donatella.Models.Pedidos
{
    public class PedidoViewModel : CarrinhoViewModel
    {
        public int Id { get; set; }
        public DateTime DtInclusao { get; set; }

        [DataType("MudaStatusPedido")]
        public TipoStatusPedido Status { get; set; }
        public string FormaDePagamento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual Uf? Uf { get; set; }
        public virtual string Cep { get; set; }
        public bool TemCpfNaNota { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}