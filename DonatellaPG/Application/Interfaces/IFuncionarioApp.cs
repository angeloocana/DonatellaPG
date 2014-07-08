using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IFuncionarioApp
    {
        IEnumerable<Funcionario> Funcionarios { get; }
        void Salvar(Funcionario funcionario, string senha, IEnumerable<Permissao> permissoes);
        Funcionario ValidarLogin(string login, string senha);
        void AlterarSenha(int funcionarioId, string senha);

        void Excluir(int funcionarioId);
    }
}
