using System.Linq;
using System.Security.Principal;
using System.Web.Http.ModelBinding.Binders;

namespace Donatella.Models.Login
{
    public class LoginPrincipal : UsuarioLogadoViewModel, IPrincipal
    {
        public LoginPrincipal(UsuarioLogadoViewModel model)
        {
            Identity = new GenericIdentity(model.UserId.ToString());
            FirstName = model.FirstName;
            UserId = model.UserId;
            LogId = model.LogId;
            Roles = model.Roles;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (Roles == null)
                return false;

            return Roles.Contains(role);
        }
    }
}