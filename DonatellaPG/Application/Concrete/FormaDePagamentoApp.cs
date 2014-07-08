using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;


namespace Application.Concrete
{
    public class EFFormaDePagamentoApp : IFormaDePagamentoApp
    {
        private EFDbContext _dbContext;

        public EFFormaDePagamentoApp()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<FormaDePagamento> FormaDePagamentos
        {
            get { return _dbContext.FormasDePagamento; }
        }

        public void Salvar(FormaDePagamento formaDePagamento)
        {
            var dbFormaDePagamento = formaDePagamento.FormaDePagamentoId == 0 ? new FormaDePagamento()
                : _dbContext.FormasDePagamento.Find(formaDePagamento.FormaDePagamentoId);

            if (dbFormaDePagamento == null)
                throw new Exception("Forma de pagamento não pode ser alterada, pois não existe no banco.");

            dbFormaDePagamento.Ativo = formaDePagamento.Ativo;
            dbFormaDePagamento.Descricao = formaDePagamento.Descricao;

            if (dbFormaDePagamento.FormaDePagamentoId == 0)
                _dbContext.FormasDePagamento.Add(dbFormaDePagamento);

            _dbContext.SaveChanges();
        }
        public void Excluir(int formaDePagamentoId)
        {
            var formaDePagamento = _dbContext.FormasDePagamento.Find(formaDePagamentoId);
            if (formaDePagamento == null) throw new Exception("Forma de pagamento não existe!");

            if (formaDePagamento.Pedidos.Any())
                throw new Exception("Forma de pagamento não pode ser excluida, pois possui pedidos vinculados!");

            _dbContext.FormasDePagamento.Remove(formaDePagamento);
            _dbContext.SaveChanges();
        }
    }
}
