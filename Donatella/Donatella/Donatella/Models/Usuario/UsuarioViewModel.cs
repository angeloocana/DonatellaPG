using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models
{
    public class UsuarioViewModel : IMapFrom<Donatella.Data.Entities.Usuario>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public Int64 Cpf { get; set; }
    }
}