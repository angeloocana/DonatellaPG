using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models;
using Donatella.Models.Enums;
using Microsoft.Ajax.Utilities;

namespace Donatella.App.Concrete
{
    public class PermissaoApp : IPermissaoApp
    {
        private readonly IRepository<UsuarioPerfilAcesso> _usuarioPerfilAcessoRepository;
        private readonly IRepository<PerfilAcesso> _perfilAcessoRepository;
        private readonly IRepository<PerfilAcessoPermissao> _perfilAcessoPermissaoRepository;

        public PermissaoApp(IRepository<UsuarioPerfilAcesso> usuarioPerfilAcessoRepository, IRepository<PerfilAcesso> PerfilAcessoRepository,
           IRepository<PerfilAcessoPermissao> perfilAcessoPermissaoRepository)
        {
            _usuarioPerfilAcessoRepository = usuarioPerfilAcessoRepository;
            _perfilAcessoRepository = PerfilAcessoRepository;
            _perfilAcessoPermissaoRepository = perfilAcessoPermissaoRepository;
        }

        public PerfilAcessoFormViewModel Perfil(int perfilAcessoId)
        {
            var todasAsPermissoes = TodasAsPermissoes().ToList();
            var perfil = (from x in _perfilAcessoRepository.Get()
                          where x.Id == perfilAcessoId
                          select new
                          {
                              x.Id,
                              x.Permissoes,
                              x.Perfil
                          }).FirstOrDefault();

            if (perfil == null)
                return null;


            foreach (var permissaoViewModel in todasAsPermissoes)
            {
                permissaoViewModel.Possui = perfil.Permissoes.Any(x => x.Permissao == permissaoViewModel.Permissao);
            }

            return new PerfilAcessoFormViewModel
            {
                Perfil = perfil.Perfil,
                PermissoesLista = todasAsPermissoes,
                Id = perfil.Id
            };
        }

        public PerfilAcesso Perfil(string perfil)
        {
            return _perfilAcessoRepository.Get().FirstOrDefault(m => m.Perfil == perfil);
        }

        public IEnumerable<PermissaoViewModel> TodasAsPermissoes()
        {
            return
                Enum.GetValues(typeof(Permissoes)).Cast<Permissoes>().Select(x => new PermissaoViewModel
                {
                    Permissao = x
                });
        }

        public IEnumerable<UsuarioPerfilAcessoViewModel> TodosOsPerfis()
        {
            return
                (from x in _perfilAcessoRepository.Get()
                 select new UsuarioPerfilAcessoViewModel
                 {
                     PerfilAcesso = x
                 });
        }

        public IEnumerable<int> PerfisUsuario(int usuarioId)
        {
            return
               (from x in _usuarioPerfilAcessoRepository.Get()
                where x.UsuarioId == usuarioId
                select x.PerfilAcessoId).ToList();
        }

        public IEnumerable<PerfilAcesso> PerfilPermissoes(int usuarioId)
        {
            return
               (from x in _usuarioPerfilAcessoRepository.Get()
                where x.UsuarioId == usuarioId
                select x.PerfilAcesso);
        }

        public IEnumerable<PermissaoViewModel> PermissoesUsuario(int usuarioId)
        {
            var todasAsPermissoes = TodasAsPermissoes();
            var permissoesUsuario = PerfilPermissoes(usuarioId).Select(x => x.Permissoes);

            foreach (var permissaoViewModel in todasAsPermissoes)
            {
                permissaoViewModel.Possui = permissoesUsuario.Any(x => x.Any(p => p.Permissao == permissaoViewModel.Permissao));
            }

            return todasAsPermissoes;
        }


        public void SalvarPerfil(PerfilAcessoFormViewModel model)
        {

            var perfil = model.Id > 0 ? _perfilAcessoRepository.Get(model.Id) : new PerfilAcesso();

            perfil.Perfil = model.Perfil;

            if (perfil.Id > 0)
                _perfilAcessoRepository.Update(perfil);
            else
                _perfilAcessoRepository.Add(perfil);

            _perfilAcessoRepository.Commit();

            AtualizarPermissoes(model.Permissoes, perfil.Id);
        }

        private void ExcluirPermissoes(IEnumerable<Permissoes> permissoes, int perfilId)
        {
            var excluirPreferencia = (from x in _perfilAcessoPermissaoRepository.Get()
                                      where x.PerfilAcessoId == perfilId
                                      && !permissoes.Contains(x.Permissao)
                                      select x);

            _perfilAcessoPermissaoRepository.DeleteAll(excluirPreferencia);
        }

        public void AdicionarPermissoes(IEnumerable<Permissoes> permissoes, int perfilId)
        {
            var preferenciaJaCadastradas = (from x in _perfilAcessoPermissaoRepository.Get()
                                            where x.PerfilAcessoId == perfilId
                                            select x.Permissao);

            var permissoesCadastrar = (from x in permissoes
                                       where !preferenciaJaCadastradas.Contains(x)
                                       select new PerfilAcessoPermissao
                                       {
                                           Permissao = x,
                                           PerfilAcessoId = perfilId
                                       });

            _perfilAcessoPermissaoRepository.AddAll(permissoesCadastrar);
        }

        public void AtualizarPermissoes(IEnumerable<Permissoes> permissoes, int perfilId)
        {
            ExcluirPermissoes(permissoes, perfilId);
            AdicionarPermissoes(permissoes, perfilId);

            _perfilAcessoPermissaoRepository.Commit();
        }

        public IEnumerable<PerfilAcessoViewModel> ListaPermissoes()
        {
            var perfis = _perfilAcessoRepository.Get()
                    .Select(
                        x =>
                            new
                            {
                                PerfilId = x.Id,
                                Perfil = x.Perfil,
                                Permissoes = x.Permissoes.Select(p => p.Permissao.ToString())
                            }).ToList();
            return
                perfis.Select(
                        x =>
                            new PerfilAcessoViewModel()
            {
                PerfilId = x.PerfilId,
                Perfil = x.Perfil,
                Permissoes = x.Permissoes.Any() ? x.Permissoes.Aggregate((a, b) => a + "; " + b) : ""
            });
        }

        public void DeletePerfil(int? id)
        {
            var perfilAcesso = (from x in _perfilAcessoRepository.Get()
                                where x.Id == id
                                select x).FirstOrDefault();

            if (perfilAcesso == null)
                throw new Exception("Perfil não existe");

            if (perfilAcesso.Usuarios.Any())
                throw new Exception("Existem usuários com esse perfil!");

            if (perfilAcesso.Permissoes.Any())
                _perfilAcessoPermissaoRepository.DeleteAll(perfilAcesso.Permissoes.ToList());
            _perfilAcessoRepository.Delete(perfilAcesso);

            _perfilAcessoRepository.Commit();
        }

        public void ExcluirUsuarioPerfilAcesso(IEnumerable<int> Perfis, int UsuarioId)
        {
            var excluirUsuarioPerfisAcessos = (from x in _usuarioPerfilAcessoRepository.Get()
                                               where x.UsuarioId == UsuarioId
                                               && !Perfis.Contains(x.PerfilAcessoId)
                                               select x);

            _usuarioPerfilAcessoRepository.DeleteAll(excluirUsuarioPerfisAcessos);
        }

        public void AdicionarUsuarioPerfilAcesso(IEnumerable<int> Perfis, int UsuarioId)
        {
            var perfisJaCadastrados = (from x in _usuarioPerfilAcessoRepository.Get()
                                       where x.UsuarioId == UsuarioId
                                       select x.PerfilAcessoId);

            var perfisCadastrar = (from x in Perfis
                                   where !perfisJaCadastrados.Contains(x)
                                   select new UsuarioPerfilAcesso
                                   {
                                       PerfilAcessoId = x,
                                       UsuarioId = UsuarioId
                                   });

            _usuarioPerfilAcessoRepository.AddAll(perfisCadastrar);
        }

        public void AtualizarUsuarioPerfilAcesso(IEnumerable<int> Perfis, int UsuarioId)
        {
            ExcluirUsuarioPerfilAcesso(Perfis, UsuarioId);
            AdicionarUsuarioPerfilAcesso(Perfis, UsuarioId);

            _usuarioPerfilAcessoRepository.Commit();
        }
    }
}
