using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class Estado
    {
        [Key]
        [MaxLength(2)]
        public string Uf { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }

        public Uf Enum { get; set; }
    }
}