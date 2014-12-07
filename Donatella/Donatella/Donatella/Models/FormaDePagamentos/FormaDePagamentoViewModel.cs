using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models.FormaDePagamentos
{
    public class FormaDePagamentoViewModel : IMapFrom<Categoria>
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required, Display(Name = "Forma de pagamento")]
        public string NomeFormaDePagamento { get; set; }

        public bool Ativo { get; set; }
    }
}