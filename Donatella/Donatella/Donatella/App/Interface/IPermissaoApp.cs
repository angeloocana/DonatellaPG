using System.Collections.Generic;
using Donatella.Data.Entities;
using Donatella.Models;
using Donatella.Models.Enums;

namespace Donatella.App.Interface
{
    public interface IPermissaoApp
    {
        IEnumerable<PermissaoViewModel> TodasAsPermissoes();
        IEnumerable<UsuarioPerfilAcessoViewModel> TodosOsPerfis();
        IEnumerable<int> PerfisUsuario(int usuarioId);
        IEnumerable<PerfilAcesso> PerfilPermissoes(int usuarioId);
        IEnumerable<PermissaoViewModel> PermissoesUsuario(int usuarioId);
        PerfilAcessoFormViewModel Perfil(int perfilAcessoId);
        PerfilAcesso Perfil(string perfil);
        void SalvarPerfil(PerfilAcessoFormViewModel model);
        void AdicionarPermissoes(IEnumerable<Permissoes> permissoes, int perfilId);
        IEnumerable<PerfilAcessoViewModel> ListaPermissoes();
        void DeletePerfil(int? perfilId);
        void ExcluirUsuarioPerfilAcesso(IEnumerable<int> Perfis, int UsuarioId);
        void AdicionarUsuarioPerfilAcesso(IEnumerable<int> Perfis, int UsuarioId);
        void AtualizarUsuarioPerfilAcesso(IEnumerable<int> perfis, int usuarioId);
    }
}
