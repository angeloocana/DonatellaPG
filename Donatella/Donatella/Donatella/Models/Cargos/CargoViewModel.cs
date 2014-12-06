using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models.Cargos
{
    public class CargoViewModel : IMapFrom<Cargo>
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required, Display(Name = "Cargo")]
        public string NomeCargo { get; set; }
    }
}