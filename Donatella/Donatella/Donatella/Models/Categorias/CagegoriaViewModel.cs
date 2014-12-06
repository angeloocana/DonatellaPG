using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models.Categorias
{
    public class CategoriaViewModel : IMapFrom<Categoria>
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required, Display(Name = "Categoria")]
        public string NomeCategoria { get; set; }
    }
}