using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonatellaDomain.Entities;

namespace DonatellaAdmin.Models.Produtos
{
    public class ProdutoFormViewModel
    {
        public virtual int ProdutoId { get; set; }
        [StringLength(150)]
        [Required]
        public virtual string Nome { get; set; }
        public virtual decimal? PrecoDe { get; set; }
        [Required]
        public virtual decimal Preco { get; set; }

        [Required, DataType("CategoriaId")]
        public virtual int? Categoria { get; set; }
        public virtual bool Adicional { get; set; }

        public virtual bool Disponivel { get; set; }
    }
}