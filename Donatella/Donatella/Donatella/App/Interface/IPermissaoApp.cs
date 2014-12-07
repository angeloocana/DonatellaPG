using System.Collections.Generic;
using Donatella.Data.Entities;
using Donatella.Models;
using Donatella.Models.Enums;

namespace Donatella.App.Interface
{
    public interface IPermissaoApp
    {
        Dictionary<int, string> Combo();
        IEnumerable<PermissaoViewModel> TodasAsPermissoes();
       
        PerfilAcessoFormViewModel Perfil(int perfilAcessoId);
        PerfilAcesso Perfil(string perfil);
        void SalvarPerfil(PerfilAcessoFormViewModel model);
        void AdicionarPermissoes(IEnumerable<Permissoes> permissoes, int perfilId);
        IEnumerable<PerfilAcessoViewModel> ListaPermissoes();
        void DeletePerfil(int? perfilId);
        IEnumerable<Permissoes> Permissoes(int perfilId);
        string[] PermissoesString(int? perfilId);
    }
}
