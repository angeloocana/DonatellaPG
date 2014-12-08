using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models;
using Donatella.Helpers;
using Donatella.Models.Enums;
using Donatella.Models.Login;
using System.Web.Mvc;
using System.Web;
using Donatella.Models.Pedidos;

namespace Donatella.App.Concrete
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IPermissaoApp _permissaoApp;
        private readonly UrlHelper _url;

        public UsuarioApp(IRepository<Usuario> usuarioRepository,
            IPermissaoApp permissaoApp)
        {
            _usuarioRepository = usuarioRepository;
            _permissaoApp = permissaoApp;
            _url = new UrlHelper(HttpContext.Current.Request.RequestContext);
        }

        public TopoHomeViewModel Topo(int usuarioId, int participanteId)
        {
            var nomeFoto = (from x in _usuarioRepository.Get()
                            where x.Id == usuarioId
                            select new TopoHomeViewModel
                            {
                                Nome = x.Nome
                            }).FirstOrDefault();

            if (nomeFoto == null)
                return null;

            return nomeFoto;
        }

        public IEnumerable<UsuarioViewModel> Usuarios()
        {
            return
                from x in _usuarioRepository.Get()
                where x.DtInativacao == null
                select new UsuarioViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Cpf = x.Cpf,
                };
        }

        public UsuarioFormViewModel Usuario(int id)
        {
            var usuario = _usuarioRepository.Get(id);
            return Mapper.Map<UsuarioFormViewModel>(usuario);
        }

        public FecharPedidoFormViewModel DadosParaFecharPedido(int id)
        {
            var usuario = _usuarioRepository.Get(id);
            return Mapper.Map<FecharPedidoFormViewModel>(usuario); ;
        }

        public Usuario Usuario(Int64 cpf)
        {
            return _usuarioRepository.Get().FirstOrDefault(m => m.Cpf == cpf);
        }
        
        public Usuario Salvar(UsuarioFormViewModel model)
        {
            var usuario = model.Id > 0
                ? _usuarioRepository.Get(model.Id)
                : Mapper.Map<UsuarioFormViewModel, Usuario>(model);

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            if (model.Id > 0)
            {
                var perfilAcessoId = usuario.PerfilAcessoId;
                usuario = Mapper.Map(model, usuario);
                if (model.TipoTelaDeUsuario != TipoTelaDeUsuario.Admin)
                    usuario.PerfilAcessoId = perfilAcessoId;
            }

            if (usuario.Id == 0 && model.NovaSenha == null)
                throw new Exception("A senha é obrigatória");

            if (!(usuario.Cpf > 0))
                throw new Exception("CPF inválido.");

            if (JaUsouCpf(usuario.Cpf, usuario.Id))
                throw new Exception("CPF já cadastrado.");

            if (model.NovaSenha != null)
                usuario.Senha = CriptografiaHelpers.Criptografar(model.NovaSenha, usuario.Cpf.ToString());

            if (usuario.Id > 0)
                _usuarioRepository.Update(usuario);
            else
                _usuarioRepository.Add(usuario);

            _usuarioRepository.Commit();

            return usuario;
        }

        public void Excluir(int id)
        {
            _usuarioRepository.Inativar(id);
            _usuarioRepository.Commit();
        }

        public bool JaUsouCpf(Int64 cpf, int id)
        {
            return _usuarioRepository.Get().Any(m => m.Cpf == cpf && m.Id != id);
        }

        public void EnviaEsqueciSenhaToken(EsqueceuSenhaFormViewModel model)
        {
            if (!ParticipanteHelpers.IsCpf(model.Cpf))
                throw new Exception("CPF inválido.");
            var cpf = Convert.ToInt64(model.Cpf);
            var usuario = _usuarioRepository.Get().FirstOrDefault(m => m.Cpf == cpf);

            if (usuario == null)
                throw new Exception("CPF não encontrado");

            usuario.TokenSenha = ParticipanteHelpers.GeraToken();
            _usuarioRepository.Update(usuario);
            _usuarioRepository.Commit();
            EnviaEmailEsqueciSenha(usuario);
        }

        public void EnviaEmailEsqueciSenha(Usuario usuario)
        {
            string html = "<h2>Esqueceu a senha</h2>"
                + "<p><font size=2 face=arial>Olá " + usuario.Nome + ", </p><br /><br />"
                + "<p>Para trocar a sua senha <a href='" + ConfigurationManager.AppSettings["SiteUrl"] + _url.Action("TrocaSenha", "EsqueceuSenha", new { token = usuario.TokenSenha }) + "'>clique aqui</a></p><br />"
                + "Atenciosamente, <br /><br /> Equipe Donatella</font>";

            if (!Email.EnviarEmail(usuario.Email, "Donatella - Esqueceu a senha", html, true, "Donatella - Esqueceu a senha"))
                throw new Exception("Não foi possivel enviar o email.");
        }

        public void TrocaSenha(TrocaSenhaFormViewModel model)
        {
            if (!ParticipanteHelpers.IsCpf(model.Cpf))
                throw new Exception("CPF inválido.");

            var cpf = Convert.ToInt64(model.Cpf);
            var usuario = _usuarioRepository.Get().FirstOrDefault(m => m.Cpf == cpf && m.TokenSenha == model.TokenSenha);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            usuario.Senha = CriptografiaHelpers.Criptografar(model.NovaSenha, usuario.Cpf.ToString());
            usuario.TokenSenha = null;

            _usuarioRepository.Update(usuario);
            _usuarioRepository.Commit();
        }

        public void ValidarSenha(int usuarioId, string senha)
        {
            var login = (from x in _usuarioRepository.Get()
                         where x.Id == usuarioId
                         select new { x.Senha, x.Cpf }).FirstOrDefault();

            var senhaCriptografada = CriptografiaHelpers.Criptografar(senha, login.Cpf.ToString());

            if (!login.Senha.SequenceEqual(senhaCriptografada))
                throw new Exception("Senha atual inválida!");
        }

        public UsuarioLogadoViewModel ValidarLogin(LoginFormViewModel model, TipoArea area)
        {
            var login = ConversaoHelper.ToInt64(model.Login);
            var usuario = (from x in _usuarioRepository.Get()
                           where x.Cpf == login
                           select new
                           {
                               x.CargoId,
                               FirstName = x.Nome,
                               UserId = x.Id,
                               x.Senha,
                               x.DtInativacao,
                               x.PerfilAcessoId
                           }).FirstOrDefault();

            if (usuario == null)
                throw new Exception("Usuário não existe!");

            if (usuario.DtInativacao != null)
                throw new Exception("Usuário inativo!");

            var senhaCriptografada = CriptografiaHelpers.Criptografar(model.Senha, model.Login);
            if (!usuario.Senha.SequenceEqual(senhaCriptografada))
                throw new Exception("Senha inválida!");

            return new UsuarioLogadoViewModel
            {
                UserId = usuario.UserId,
                FirstName = usuario.FirstName,
                Roles = _permissaoApp.PermissoesString(usuario.PerfilAcessoId)
            };
        }
    }
}








