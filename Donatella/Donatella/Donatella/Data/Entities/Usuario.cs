using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class Usuario : EntityBase
    {
        [ForeignKey("Cargo")]
        public virtual int? CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public bool FlTeste { get; set; }

        [MaxLength(200)]
        public virtual string Nome { get; set; }

        [EmailAddress, MaxLength(250)]
        public virtual string Email { get; set; }

        [Index(IsUnique = true)]
        public virtual Int64 Cpf { get; set; }
        
        [MaxLength]
        public virtual byte[] Senha { get; set; }
        
        [MaxLength(50)]
        public virtual string TokenSenha { get; set; }

        public virtual Sexo? Sexo { get; set; }
        
        public virtual DateTime? DtNascimento { get; set; }
        
        [MaxLength(15)]
        public virtual string Telefone { get; set; }

        [MaxLength(15)]
        public virtual string Celular { get; set; }

        [ForeignKey("PerfilAcesso")]
        public int? PerfilAcessoId { get; set; }
        public virtual PerfilAcesso PerfilAcesso { get; set; }

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
    }
}