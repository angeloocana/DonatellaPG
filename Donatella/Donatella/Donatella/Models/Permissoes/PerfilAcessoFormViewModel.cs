using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;
using Donatella.Models.Enums;

namespace Donatella.Models
{
    public class PerfilAcessoFormViewModel : IMapFrom<PerfilAcesso>
    {
        public int Id { get; set; }
        public string Perfil { get; set; }

        [DataType("Permissoes")]
        public IEnumerable<PermissaoViewModel> PermissoesLista { get; set; }

        public IEnumerable<Permissoes> Permissoes { get; set; }
    }
}