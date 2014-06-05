using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFEstoqueRepository : IEstoqueRepository
    {
        private EFDbContext _dbContext;

        public EFEstoqueRepository()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Estoque> Estoques
        {
            get { return _dbContext.Estoques; }
        }

        public void SalvarEstoque(Estoque estoque)
        {
            var dbEstoque = estoque.EstoqueId == 0 ? new Estoque()
                : _dbContext.Estoques.Find(estoque.EstoqueId);
        
            if(dbEstoque == null)
                throw new Exception("Estoque não pode ser alterado, pois não existe no banco.");

            dbEstoque.Data = estoque.Data;
            dbEstoque.Fornecedor = estoque.Fornecedor;
            dbEstoque.Ingrediente = estoque.Ingrediente;
            dbEstoque.Obs = estoque.Obs;
            dbEstoque.Quantidade = estoque.Quantidade;

            if (dbEstoque.EstoqueId == 0)
                _dbContext.Estoques.Add(dbEstoque);

            _dbContext.SaveChanges();
        }
    }
}
