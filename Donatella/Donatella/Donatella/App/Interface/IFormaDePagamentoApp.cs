using System.Collections.Generic;
using Donatella.Models.FormaDePagamentos;
using Donatella.Data.Entities;

namespace Donatella.App.Interface
{
    public interface IFormaDePagamentoApp
    {
        Dictionary<int, string> Combo();
        FormaDePagamento FindByNome(string nome);
        void Salvar(FormaDePagamentoViewModel formaDePagamento);
        void Excluir(int formaDePagamentoId);
        FormaDePagamentoViewModel FormaDePagamento(int id);
        IEnumerable<FormaDePagamento> FormaDePagamentos();
    }
}