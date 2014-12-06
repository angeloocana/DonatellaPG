using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models.Enums;

namespace Donatella.App.Concrete
{
    public class UsuarioPerfilAcessoApp : IUsuarioPerfilAcessoApp
    {
        private readonly IRepository<UsuarioPerfilAcesso> _usuarioPerfilAcessoRepository;

        public UsuarioPerfilAcessoApp(IRepository<UsuarioPerfilAcesso> usuarioPerfilAcessoRepository)
        {
            _usuarioPerfilAcessoRepository = usuarioPerfilAcessoRepository;
        }

        public IEnumerable<Permissoes> Permissoes(int usuarioId)
        {
            var permissoes = new List<Permissoes>();
            var perfilPermissoes = from x in _usuarioPerfilAcessoRepository.Get()
                                   where x.UsuarioId == usuarioId
                                   select x.PerfilAcesso.Permissoes.Select(p => p.Permissao);

            foreach (var permissao in perfilPermissoes)
                permissoes.AddRange(permissao);

            return permissoes.Distinct();
        }
    }
}