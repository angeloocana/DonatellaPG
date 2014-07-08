using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Concrete
{
    public class FormaDePagamentoApp : AppBase, IFormaDePagamentoApp
    {
        private IRepositoryBase<FormaDePagamento> _formaDePagamentoRepository;
        public FormaDePagamentoApp(IRepositoryBase<FormaDePagamento> formaDePagamentoRepository)
        {
            _formaDePagamentoRepository = formaDePagamentoRepository;
        }
        public IEnumerable<FormaDePagamento> FormaDePagamentos
        {
            get { return _formaDePagamentoRepository.Get(); }
        }

        public void Salvar(FormaDePagamento formaDePagamento)
        {
            BeginTransaction();

            var dbFormaDePagamento = formaDePagamento.FormaDePagamentoId == 0 ? new FormaDePagamento()
                : _formaDePagamentoRepository.Get(formaDePagamento.FormaDePagamentoId);

            if (dbFormaDePagamento == null)
                throw new Exception("Forma de pagamento não pode ser alterada, pois não existe no banco.");

            dbFormaDePagamento.Ativo = formaDePagamento.Ativo;
            dbFormaDePagamento.Descricao = formaDePagamento.Descricao;

            if (dbFormaDePagamento.FormaDePagamentoId == 0)
                _formaDePagamentoRepository.Add(dbFormaDePagamento);

            Commint();
        }
        public void Excluir(int formaDePagamentoId)
        {
            BeginTransaction();

            var formaDePagamento = _formaDePagamentoRepository.Get(formaDePagamentoId);
            if (formaDePagamento == null) throw new Exception("Forma de pagamento não existe!");

            if (formaDePagamento.Pedidos.Any())
                throw new Exception("Forma de pagamento não pode ser excluida, pois possui pedidos vinculados!");

            _formaDePagamentoRepository.Delete(formaDePagamento);

            Commint();
        }
    }
}
