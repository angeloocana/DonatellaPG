using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface IFormaDePagamentoRepository
    {
        IQueryable<FormaDePagamento> FormaDePagamentos { get; }
        void SalvarFormaDePagamento(FormaDePagamento formaDePagamento);
    }
}