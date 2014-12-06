using System.Collections.Generic;
using Antlr.Runtime.Tree;
using Donatella.Data.Entities;
using Donatella.Data.Scripts;
using Donatella.Helpers;
using Donatella.Models.Enums;

namespace Donatella.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Donatella.Data.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Donatella.Data.EfDbContext context)
        {
            EstadosSeed.Seed(context);
            
            #region Perfis

            var perfilMaster = new PerfilAcesso
            {
                Perfil = "Master",
                DtInclusao = DateTime.Now,
                DtAlteracao = DateTime.Now
            };

            context.PerfilAcessos.AddOrUpdate(
              p => p.Perfil,
              perfilMaster
            );

            context.SaveChanges();

            #endregion

            #region Perfil Permissao

            var permissoes =
                EnumHelper<Permissoes>.GetValues()
                    .Select(
                        x =>
                            new PerfilAcessoPermissao
                            {
                                DtInclusao = DateTime.Now,
                                DtAlteracao = DateTime.Now,
                                PerfilAcessoId = perfilMaster.Id,
                                Permissao = x
                            });

            foreach (var permissao in permissoes)
            {
                if (!context.PerfilAcessoPermissao.Any(x => x.PerfilAcessoId == perfilMaster.Id && x.Permissao == permissao.Permissao))
                    context.PerfilAcessoPermissao.AddOrUpdate(permissao);
            }
            
            context.SaveChanges();

            #endregion

            #region Usuários Adm

            CriarUsuarioAdmin(context, 123456, "Admin Master", "angeloocana@gmail.com", "admin", perfilMaster.Id);

            #endregion
        }

        private void CriarUsuarioAdmin(Data.EfDbContext context, Int64 cpf, string nome, string email, string senha, int perfilId)
        {
            if (!context.Usuarios.Any(x => x.Cpf == cpf))
            {
                var usuario = new Usuario
                {
                    Cpf = cpf,
                    Nome = nome,
                    Email = email,
                    Senha = CriptografiaHelpers.Criptografar(senha, cpf.ToString()),
                    DtInclusao = DateTime.Now
                };
                context.Usuarios.Add(usuario);
                context.SaveChanges();

                var usuarioPerfil = new UsuarioPerfilAcesso
                {
                    DtInclusao = DateTime.Now,
                    DtAlteracao = DateTime.Now,
                    PerfilAcessoId = perfilId,
                    UsuarioId = usuario.Id
                };

                context.UsuarioPerfilsPermissao.AddOrUpdate(usuarioPerfil);
                context.SaveChanges();
            }
        }
    }
}
