using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Carrinho
    {
        [Key]
        public virtual int CarrinhoId { get; set; }
        /// <summary>
        /// Se for acompanhamento marcar o produto pai, ex: adicional de bacon na pizza x
        /// </summary>
        public virtual Carrinho CarrinhoPai { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual int Mesa { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual int Quantidade { get; set; }
        [StringLength(250)]
        public virtual string Obs { get; set; }
    }
}
