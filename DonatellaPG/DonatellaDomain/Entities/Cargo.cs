﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Cargo
    {
        [Key]
        public virtual int CargoId { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string NomeCargo { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }

    }
}
