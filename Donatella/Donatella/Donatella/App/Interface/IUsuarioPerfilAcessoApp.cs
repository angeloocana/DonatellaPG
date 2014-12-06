using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Models.Enums;

namespace Donatella.App.Interface
{
    public interface IUsuarioPerfilAcessoApp
    {
        IEnumerable<Permissoes> Permissoes(int usuarioId);
    }
}