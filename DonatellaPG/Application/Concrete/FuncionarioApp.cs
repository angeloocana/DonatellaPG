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
    public class FuncionarioApp : AppBase, IFuncionarioApp
    {
        private IRepositoryBase<Funcionario> _funcionarioRepository;
        private IRepositoryBase<Cargo> _cargoRepository;
        public FuncionarioApp(IRepositoryBase<Funcionario> funcionarioRepository, IRepositoryBase<Cargo> cargoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
        }
        public IEnumerable<Funcionario> Funcionarios
        {
            get { return _funcionarioRepository.Get(); }
        }

        public void Salvar(Funcionario funcionario, string senha, IEnumerable<Permissao> permissoes)
        {
            BeginTransaction();

            var dbFuncionario = funcionario.FuncionarioId == 0 ? new Funcionario()
                : _funcionarioRepository.Get(funcionario.FuncionarioId);

            if (dbFuncionario == null)
                throw new Exception("Funcionario não pode ser alterado, pois não existe no banco.");

            dbFuncionario.Bairro = funcionario.Bairro;
            dbFuncionario.CEP = funcionario.CEP;
            dbFuncionario.CPF = funcionario.CPF;
            dbFuncionario.Celular = funcionario.Celular;
            dbFuncionario.CelularDDD = funcionario.CelularDDD;
            dbFuncionario.Cidade = funcionario.Cidade;
            dbFuncionario.Complemento = funcionario.Complemento;
            dbFuncionario.Email = funcionario.Email;
            dbFuncionario.Endereco = funcionario.Endereco;
            dbFuncionario.Estado = funcionario.Estado;
            dbFuncionario.NomeFuncionario = funcionario.NomeFuncionario;
            dbFuncionario.Numero = funcionario.Numero;
            dbFuncionario.Telefone = funcionario.Telefone;
            dbFuncionario.TelefoneDDD = funcionario.TelefoneDDD;
            dbFuncionario.Ativo = funcionario.Ativo;
            dbFuncionario.Cargo = _cargoRepository.Get(funcionario.Cargo.CargoId);

            //if (!string.IsNullOrEmpty(senha))
            //    dbFuncionario.Senha = Criptografia.Criptografar(senha, dbFuncionario.CPF);

            if (dbFuncionario.FuncionarioId == 0)
                _funcionarioRepository.Add(dbFuncionario);

            Commint();

            SalvarPermissoes(dbFuncionario, permissoes);
        }

        private void SalvarPermissoes(Funcionario dbFuncionario, IEnumerable<Permissao> permissoes)
        {
            if (dbFuncionario.Permissoes != null && dbFuncionario.Permissoes.Any())
            {
                //_dbContext.FuncionariosPermissoes.RemoveRange(dbFuncionario.Permissoes);
                //_dbContext.SaveChanges();
            }

            //if (permissoes == null || !permissoes.Any()) return;
            //foreach (var permissao in permissoes)
            //    _dbContext.FuncionariosPermissoes.Add(new FuncionarioPermissao()
            //    {
            //        DataInclusao = DateTime.Now,
            //        Funcionario = dbFuncionario,
            //        Permissao = permissao
            //    });

            //_dbContext.SaveChanges();
        }

        public Funcionario ValidarLogin(string login, string senha)
        {
            return _funcionarioRepository.First();
            //var senhaCriptografada = Criptografia.Criptografar(senha, login);
            //return _dbContext.Funcionarios.FirstOrDefault(f => f.Ativo && f.CPF == login && f.Senha == senhaCriptografada);
        }

        public void AlterarSenha(int funcionarioId, string senha)
        {
            //var funcionario = _dbContext.Funcionarios.Find(funcionarioId);
            //if (funcionario == null)
            //    throw new Exception("Funcionario não existe!");

            //funcionario.Senha = Criptografia.Criptografar(senha, funcionario.CPF);
            //_dbContext.SaveChanges();
        }

        public void Excluir(int funcionarioId)
        {
            BeginTransaction();

            var funcionario = _funcionarioRepository.Get(funcionarioId);
            if (funcionario == null) throw new Exception("Funcionario não existe!");

            //_dbContext.FuncionariosPermissoes.RemoveRange(funcionario.Permissoes);
            _funcionarioRepository.Delete(funcionario);

            Commint();
        }
    }
}
