using System.Collections.Generic;
using System.Linq;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IFormaDePagamentoApp
    {
        IEnumerable<FormaDePagamento> FormaDePagamentos { get; }
        void Salvar(FormaDePagamento formaDePagamento);

        void Excluir(int formaDePagamentoId);
    }
}