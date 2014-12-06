using System;
using System.Web;
using Donatella.Models.Enums;
using Donatella.Models.Login;

namespace Donatella.Helpers
{
    public class UsuarioLogado
    {
        public static LoginPrincipal CurrentUser
        {
            get { return System.Web.HttpContext.Current.User as LoginPrincipal; }
        }

        public static bool Logado { get { return CurrentUser != null; } }

        public static bool TemPermissao(Permissoes permissao)
        {

            if (CurrentUser == null)
                return false;
            return CurrentUser.IsInRole(permissao.ToString());
        }
    }
}