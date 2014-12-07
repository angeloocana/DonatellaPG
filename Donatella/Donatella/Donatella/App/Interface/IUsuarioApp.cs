using System;
using System.Collections.Generic;
using Donatella.Data.Entities;
using Donatella.Models;
using Donatella.Models.Enums;
using Donatella.Models.Login;

namespace Donatella.App.Interface
{
    public interface IUsuarioApp
    {
        TopoHomeViewModel Topo(int usuarioId, int participanteId);
        void ValidarSenha(int usuarioId, string senha);
        Usuario Salvar(UsuarioFormViewModel usuario);
        bool JaUsouCpf(Int64 cpf, int id);
        UsuarioFormViewModel Usuario(int id);
        Usuario Usuario(Int64 cpf);
        IEnumerable<UsuarioViewModel> Usuarios();
        void Excluir(int id);
        void EnviaEsqueciSenhaToken(EsqueceuSenhaFormViewModel model);
        void EnviaEmailEsqueciSenha(Usuario usuario);
        void TrocaSenha(TrocaSenhaFormViewModel model);
        UsuarioLogadoViewModel ValidarLogin(LoginFormViewModel model, TipoArea area);
    }
}