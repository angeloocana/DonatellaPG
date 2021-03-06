﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class FuncionarioPermissao
    {
        [Key]
        public virtual int FuncionarioPermissaoId { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public virtual Permissao Permissao { get; set; }
        [Required]
        public virtual DateTime DataInclusao { get; set; }
    }
}
