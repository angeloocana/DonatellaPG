using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFFuncionarioRepository : IFuncionarioRepository
    {
        private EFDbContext _dbContext;

        public EFFuncionarioRepository()
        {
            _dbContext = new EFDbContext();
        }
        IQueryable<Funcionario> IFuncionarioRepository.Funcionarios
        {
            get { return _dbContext.Funcionarios; }
        }

        void IFuncionarioRepository.SalvarFuncionario(Funcionario funcionario)
        {
            var dbFuncionario = funcionario.FuncionarioId == 0 ? new Funcionario()
                : _dbContext.Funcionarios.Find(funcionario.FuncionarioId);
        
            if(dbFuncionario == null)
                throw new Exception("Funcionario não pode ser alterado, pois não existe no banco.");

            dbFuncionario.Bairro = funcionario.Bairro;
            dbFuncionario.CEP = funcionario.CEP;
            dbFuncionario.CPF = funcionario.CPF;
            dbFuncionario.Celular = funcionario.Celular;
            dbFuncionario.CelularDDD = funcionario.CelularDDD;
            dbFuncionario.Cidade = funcionario.Cidade;
            dbFuncionario.Email = funcionario.Email;
            dbFuncionario.Endereco = funcionario.Endereco;
            dbFuncionario.Estado = funcionario.Estado;
            dbFuncionario.NomeFuncionario = funcionario.NomeFuncionario;
            dbFuncionario.Numero = funcionario.Numero;
            dbFuncionario.Telefone = funcionario.Telefone;
            dbFuncionario.TelefoneDDD = funcionario.TelefoneDDD;
            
            if (dbFuncionario.FuncionarioId == 0)
                _dbContext.Funcionarios.Add(dbFuncionario);

            _dbContext.SaveChanges();
        }

        Funcionario IFuncionarioRepository.ValidarLogin(string login, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
