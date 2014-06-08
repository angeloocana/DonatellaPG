using System.Collections.Generic;
using DonatellaDomain.Concrete;

namespace DonatellaDomain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DonatellaDomain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<DonatellaDomain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DonatellaDomain.Concrete.EFDbContext context)
        {
            var senha = Criptografia.Criptografar("admin", "admin");
            var funcionario = new Funcionario()
            {
                Ativo = true,
                CPF = "admin",
                Senha = senha,
                NomeFuncionario = "Admin",
                Email = "admin@admin.com.br"
            };

            context.Funcionarios.AddOrUpdate(f => f.CPF, funcionario);

            var todasAsPermissoes = Enum.GetValues(typeof(Permissao)).Cast<Permissao>().ToList();
            var permissoesQuePossui = context.FuncionariosPermissoes.Where(p => p.Funcionario.FuncionarioId == funcionario.FuncionarioId)
                .Select(p => p.Permissao).ToList();
            var permissoesParaAdicionar = todasAsPermissoes.Where(p => !permissoesQuePossui.Contains(p));

            foreach (var permissao in permissoesParaAdicionar)
                context.FuncionariosPermissoes.Add(new FuncionarioPermissao()
                {
                    DataInclusao = DateTime.Now,
                    Funcionario = funcionario,
                    Permissao = permissao
                });
        }
    }
}
