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
    public class EstoqueApp : AppBase, IEstoqueApp
    {
        private IRepositoryBase<Estoque> _estoqueRepository;
        public EstoqueApp(IRepositoryBase<Estoque> estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        public IEnumerable<Estoque> Estoques
        {
            get { return _estoqueRepository.Get(); }
        }

        public void SalvarEstoque(Estoque estoque)
        {
            BeginTransaction();

            var dbEstoque = estoque.EstoqueId == 0 ? new Estoque()
                : _estoqueRepository.Get(estoque.EstoqueId);
        
            if(dbEstoque == null)
                throw new Exception("Estoque não pode ser alterado, pois não existe no banco.");

            dbEstoque.Data = estoque.Data;
            dbEstoque.Fornecedor = estoque.Fornecedor;
            dbEstoque.Ingrediente = estoque.Ingrediente;
            dbEstoque.Obs = estoque.Obs;
            dbEstoque.Quantidade = estoque.Quantidade;

            if (dbEstoque.EstoqueId == 0)
                _estoqueRepository.Add(dbEstoque);

            Commint();
        }
    }
}
