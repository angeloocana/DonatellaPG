using System;
using System.Linq;
using Infra.Repositories.EF;
using System.Data.Entity.Migrations;

namespace Infra.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFDbContext context)
        {
            //var senha = Criptografia.Criptografar("admin", "admin");
            //var funcionario = new Funcionario()
            //{
            //    Ativo = true,
            //    CPF = "admin",
            //    Senha = senha,
            //    NomeFuncionario = "Admin",
            //    Email = "admin@admin.com.br"
            //};

            //context.Funcionarios.AddOrUpdate(f => f.CPF, funcionario);

            //var todasAsPermissoes = Enum.GetValues(typeof(Permissao)).Cast<Permissao>().ToList();
            //var permissoesQuePossui = context.FuncionariosPermissoes.Where(p => p.Funcionario.FuncionarioId == funcionario.FuncionarioId)
            //    .Select(p => p.Permissao).ToList();
            //var permissoesParaAdicionar = todasAsPermissoes.Where(p => !permissoesQuePossui.Contains(p));

            //foreach (var permissao in permissoesParaAdicionar)
            //    context.FuncionariosPermissoes.Add(new FuncionarioPermissao()
            //    {
            //        DataInclusao = DateTime.Now,
            //        Funcionario = funcionario,
            //        Permissao = permissao
            //    });
        }
    }
}
