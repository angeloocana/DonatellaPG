﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Produto
    {
        [Key]
        public virtual int ProdutoId { get; set; }
        [StringLength(150)]
        [Required]
        public virtual string Nome { get; set; }
        public virtual decimal? PrecoDe { get; set; }
        [Required]
        public virtual decimal Preco { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual bool Adicional { get; set; }

        public virtual bool Disponivel { get; set; }
    }
}
