﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;


namespace Application.Concrete
{
    public class EFFuncionarioApp : IFuncionarioApp
    {
        private EFDbContext _dbContext;

        public EFFuncionarioApp()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Funcionario> Funcionarios
        {
            get { return _dbContext.Funcionarios; }
        }

        public void Salvar(Funcionario funcionario, string senha, IEnumerable<Permissao> permissoes)
        {
            var dbFuncionario = funcionario.FuncionarioId == 0 ? new Funcionario()
                : _dbContext.Funcionarios.Find(funcionario.FuncionarioId);

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
            dbFuncionario.Cargo = _dbContext.Cargos.FirstOrDefault(c => c.CargoId == funcionario.Cargo.CargoId);

            if (!string.IsNullOrEmpty(senha))
                dbFuncionario.Senha = Criptografia.Criptografar(senha, dbFuncionario.CPF);

            if (dbFuncionario.FuncionarioId == 0)
                _dbContext.Funcionarios.Add(dbFuncionario);

            _dbContext.SaveChanges();

            SalvarPermissoes(dbFuncionario, permissoes);
        }

        private void SalvarPermissoes(Funcionario dbFuncionario, IEnumerable<Permissao> permissoes)
        {
            if (dbFuncionario.Permissoes != null)
            {
                var dbPermissoes = dbFuncionario.Permissoes.ToList();
                if (dbPermissoes.Any())
                {
                    foreach (var permissao in dbPermissoes)
                        _dbContext.FuncionariosPermissoes.Remove(permissao);

                    _dbContext.SaveChanges();
                }
            }

            if (permissoes == null || !permissoes.Any()) return;
            foreach (var permissao in permissoes)
                _dbContext.FuncionariosPermissoes.Add(new FuncionarioPermissao()
                {
                    DataInclusao = DateTime.Now,
                    Funcionario = dbFuncionario,
                    Permissao = permissao
                });

            _dbContext.SaveChanges();
        }

        public Funcionario ValidarLogin(string login, string senha)
        {
            var senhaCriptografada = Criptografia.Criptografar(senha, login);
            return _dbContext.Funcionarios.FirstOrDefault(f => f.Ativo && f.CPF == login && f.Senha == senhaCriptografada);
        }

        public void AlterarSenha(int funcionarioId, string senha)
        {
            var funcionario = _dbContext.Funcionarios.Find(funcionarioId);
            if (funcionario == null)
                throw new Exception("Funcionario não existe!");

            funcionario.Senha = Criptografia.Criptografar(senha, funcionario.CPF);
            _dbContext.SaveChanges();
        }

        public void Excluir(int funcionarioId)
        {
            var funcionario = _dbContext.Funcionarios.Find(funcionarioId);
            if (funcionario == null) throw new Exception("Funcionario não existe!");

            _dbContext.FuncionariosPermissoes.RemoveRange(funcionario.Permissoes);
            _dbContext.Funcionarios.Remove(funcionario);
            _dbContext.SaveChanges();
        }
    }
}