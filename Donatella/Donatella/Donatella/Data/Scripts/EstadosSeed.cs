using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Donatella.Data.Entities;
using Donatella.Helpers;
using Donatella.Models.Enums;

namespace Donatella.Data.Scripts
{
    public class EstadosSeed
    {
        public static void Seed(Donatella.Data.EfDbContext context)
        {
            if (context.Estados.Any())
                return;

            var estados = Enum.GetValues(typeof(Uf)).Cast<Uf>().Select(s => new Estado
            {
                Descricao = EnumHelper<Uf>.GetDisplayValue(s),
                Enum = s,
                Uf = Enum.GetName(typeof(Uf), s)
            }).ToList();
            context.Estados.AddRange(estados);
            context.SaveChanges();
        }
    }
}