using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models.FormaDePagamentos;

namespace Donatella.App.Concrete
{
    public class FormaDePagamentoApp : IFormaDePagamentoApp
    {
        private readonly IRepository<FormaDePagamento> _formaDePagamentoRepository;

        public FormaDePagamentoApp(IRepository<FormaDePagamento> formaDePagamentoRepository)
        {
            _formaDePagamentoRepository = formaDePagamentoRepository;
        }

        public Dictionary<int, string> Combo()
        {
            return (from x in _formaDePagamentoRepository.Get()
                    where x.DtInativacao == null
                    orderby x.NomeFormaDePagamento
                    select new
                    {
                        x.NomeFormaDePagamento,
                        x.Id
                    }).ToDictionary(x => x.Id, x => x.NomeFormaDePagamento);
        }

        public FormaDePagamento FindByNome(string nome)
        {
            return _formaDePagamentoRepository.Get().FirstOrDefault(m => m.NomeFormaDePagamento == nome);
        }

        public IEnumerable<FormaDePagamento> FormaDePagamentos()
        {
             return _formaDePagamentoRepository.Get(); 
        }

        public FormaDePagamentoViewModel FormaDePagamento(int id)
        {
            var formaDePagamento = _formaDePagamentoRepository.Get(id);
            return Mapper.Map<FormaDePagamentoViewModel>(formaDePagamento);
        }

        public void Salvar(FormaDePagamentoViewModel formaDePagamento)
        {
            var dbFormaDePagamento = formaDePagamento.Id == 0 ? new FormaDePagamento()
                : _formaDePagamentoRepository.Get(formaDePagamento.Id);

            if (dbFormaDePagamento == null)
                throw new Exception("FormaDePagamento não pode ser alterado, pois não existe no banco.");

            dbFormaDePagamento.NomeFormaDePagamento = formaDePagamento.NomeFormaDePagamento;
            dbFormaDePagamento.DtInativacao = formaDePagamento.Ativo ? (DateTime?)null : DateTime.Now;

            _formaDePagamentoRepository.AddOrUpdate(dbFormaDePagamento);
            _formaDePagamentoRepository.Commit();
        }

        public void Excluir(int formaDePagamentoId)
        {
            var formaDePagamento = _formaDePagamentoRepository.Get(formaDePagamentoId);
            if (formaDePagamento == null) throw new Exception("Forma de pagamento não existe!");

            if (formaDePagamento.Pedidos.Any())
                throw new Exception("Forma de pagamento não pode ser excluida, pois possui pedidos vinculados!");

            _formaDePagamentoRepository.Delete(formaDePagamento);
            _formaDePagamentoRepository.Commit();
        }
    }
}