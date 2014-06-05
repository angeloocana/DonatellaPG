﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFFormaDePagamentoRepository : IFormaDePagamentoRepository
    {
        private EFDbContext _dbContext;

        public EFFormaDePagamentoRepository()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<FormaDePagamento> FormaDePagamentos
        {
            get { return _dbContext.FormasDePagamento; }
        }

        public void SalvarFormaDePagamento(FormaDePagamento formaDePagamento)
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
    }
}