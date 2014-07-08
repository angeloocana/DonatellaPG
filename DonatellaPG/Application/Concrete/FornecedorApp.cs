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
    public class FornecedorApp : AppBase, IFornecedorApp
    {
        private IRepositoryBase<Fornecedor> _fornecedorRepository;
        public FornecedorApp(IRepositoryBase<Fornecedor> fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }
        public IEnumerable<Fornecedor> Fornecedores
        {
            get { return _fornecedorRepository.Get(); }
        }

        public void SalvarFornecedor(Fornecedor fornecedor)
        {
            BeginTransaction();

            var dbFornecedor = fornecedor.FornecedorId == 0 ? new Fornecedor()
                : _fornecedorRepository.Get(fornecedor.FornecedorId);
        
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
                _fornecedorRepository.Add(dbFornecedor);
            
            Commint();
        }
    }
}
