using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFFornecedorRepository : IFornecedorRepository
    {
        private EFDbContext _dbContext;

        public EFFornecedorRepository()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Fornecedor> Fornecedores
        {
            get { return _dbContext.Fornecedores; }
        }

        public void SalvarFornecedor(Fornecedor fornecedor)
        {
            var dbFornecedor = fornecedor.FornecedorId == 0 ? new Fornecedor()
                : _dbContext.Fornecedores.Find(fornecedor.FornecedorId);
        
            if(dbFornecedor == null)
                throw new Exception("Fornecedor não pode ser alterado, pois não existe no banco.");

            dbFornecedor.Bairro = fornecedor.Bairro;
            dbFornecedor.CEP = fornecedor.CEP;
            dbFornecedor.CNPJ = fornecedor.CNPJ;
            dbFornecedor.Celular = fornecedor.CNPJ;
            dbFornecedor.CelularDDD = fornecedor.CelularDDD;
            dbFornecedor.Cidade = fornecedor.Cidade;
            dbFornecedor.Email = fornecedor.Email;
            dbFornecedor.Endereco = fornecedor.Endereco;
            dbFornecedor.Estado = fornecedor.Estado;
            dbFornecedor.NomeContato = fornecedor.NomeContato;
            dbFornecedor.NomeFantasia = fornecedor.NomeFantasia;
            dbFornecedor.Numero = fornecedor.Numero;
            dbFornecedor.RazaoSocial = fornecedor.RazaoSocial;
            dbFornecedor.Telefone = fornecedor.Telefone;
            dbFornecedor.TelefoneDDD = fornecedor.TelefoneDDD;

            if (dbFornecedor.FornecedorId == 0)
                _dbContext.Fornecedores.Add(dbFornecedor);

            _dbContext.SaveChanges();
        }
    }
}
