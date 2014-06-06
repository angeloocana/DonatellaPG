using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface IFuncionarioRepository
    {
        IQueryable<Funcionario> Funcionarios { get; }
        void Salvar(Funcionario funcionario, string senha, IEnumerable<Permissao> permissoes);
        Funcionario ValidarLogin(string login, string senha);
        void AlterarSenha(int funcionarioId, string senha);

        void Excluir(int funcionarioId);
    }
}
