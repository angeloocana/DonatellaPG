using System.ComponentModel.DataAnnotations;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;
using Donatella.Models.Enums;

namespace Donatella.Models.Pedidos
{
    public class FecharPedidoFormViewModel : IHaveCustomMappings
    {
        [Required, Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [MaxLength(150), Display(Name = "Endereço"), Required]
        public virtual string Logradouro { get; set; }

        [MaxLength(150)]
        public virtual string Complemento { get; set; }

        [MaxLength(50), Display(Name = "Número"), Required]
        public virtual string Numero { get; set; }

        [MaxLength(150), Required]
        public virtual string Bairro { get; set; }

        [MaxLength(150), Required]
        public virtual string Cidade { get; set; }

        [DataType("Uf"), Display(Name = "Estado"), Required]
        public virtual Uf? Uf { get; set; }

        [MaxLength(12), Display(Name = "CEP"), Required]
        public virtual string Cep { get; set; }

        [Required]
        [DataType("FormaDePagamentoId"), Display(Name = "Forma de Pagamento")]
        public int FormaDePagamentoId { get; set; }

        [Display(Name = "CPF na nota?")]
        public bool TemCpfNaNota { get; set; }
        public string Cpf { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Usuario, FecharPedidoFormViewModel>();
            configuration.CreateMap<FecharPedidoFormViewModel, Pedido>();
        }
    }
}