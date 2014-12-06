using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class Usuario : EntityBase
    {
        public bool IsAdmin { get; set; }

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

        [MaxLength(300)]
        public virtual string Foto { get; set; }

        [MaxLength]
        public virtual byte[] Senha { get; set; }
        
        public virtual bool SenhaBloqueada { get; set; }

        public virtual int ErrosDeSenha { get; set; }

        [MaxLength(50)]
        public virtual string TokenSenha { get; set; }

        public virtual Sexo? Sexo { get; set; }
        
        public virtual DateTime? DtNascimento { get; set; }

        [ForeignKey("Endereco")]
        public virtual int? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        [MaxLength(10)]
        public virtual string TelResidencial { get; set; }
        [MaxLength(2)]
        public virtual string TelResidencialDdd { get; set; }

        [MaxLength(10)]
        public virtual string TelCelular { get; set; }
        [MaxLength(2)]
        public virtual string TelCelularDdd { get; set; }
        
        public virtual ICollection<UsuarioPerfilAcesso> PerfilsPermissoes { get; set; }
    }
}