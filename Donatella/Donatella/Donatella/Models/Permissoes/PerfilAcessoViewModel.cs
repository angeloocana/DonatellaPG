using System.ComponentModel.DataAnnotations;

namespace Donatella.Models
{
    public class PerfilAcessoViewModel
    {
        public int? PerfilId { get; set; }

        public string Perfil { get; set; }

        public string Permissoes { get; set; }
    }
}