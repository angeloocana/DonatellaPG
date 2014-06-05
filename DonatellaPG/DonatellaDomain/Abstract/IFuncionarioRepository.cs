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
        void SalvarFuncionario(Funcionario funcionario);
        Funcionario ValidarLogin(string login, string senha);
    }
}
