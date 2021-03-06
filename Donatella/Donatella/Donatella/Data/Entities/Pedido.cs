﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class Pedido : EntityBase
    {
        [Required]
        public virtual decimal ValorTotal { get; set; }

        [ForeignKey("FormaDePagamento")]
        public int FormaDePagamentoId { get; set; }
        public virtual FormaDePagamento FormaDePagamento { get; set; }
        
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public TipoStatusPedido StatusPedido { get; set; }
        public virtual int? NotaAvaliacao { get; set; }

        [Required, Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [MaxLength(150), Display(Name = "Endereço"), Required]
        public virtual string Logradouro { get; set; }

        [MaxLength(150)]
        public virtual string Complemento { get; set; }

        [MaxLength(50), Display(Name = "Número"), Required]
        public virtual string Numero { get; set; }

        [MaxLength(150), Required]
        public virtual string Bairro { get; set; }

        [MaxLength(150), Required]
        public virtual string Cidade { get; set; }

        [DataType("Uf"), Display(Name = "Estado"), Required]
        public virtual Uf? Uf { get; set; }

        [MaxLength(12), Display(Name = "CEP"), Required]
        public virtual string Cep { get; set; }
        
        [Display(Name = "CPF na nota?")]
        public bool TemCpfNaNota { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<PedidoProduto> Produtos { get; set; }
    }
}
