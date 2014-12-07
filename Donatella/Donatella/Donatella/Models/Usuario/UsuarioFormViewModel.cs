using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;
using Donatella.Models.Enums;

namespace Donatella.Models
{
    public class UsuarioFormViewModel : IMapFrom<Usuario>
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        public string Cpf { get; set; }

        [DataType("CargoId"), Display(Name = "Cargo")]
        public int? CargoId { get; set; }

        [DataType("PerfilAcessoId"), Display(Name = "Perfil")]
        public int? PerfilAcessoId { get; set; }

        [HiddenInput]
        public TipoTelaDeUsuario TipoTelaDeUsuario { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Dt Nascimento")]
        public DateTime? DtNascimento { get; set; }
        
        [Required, DataType("Sexo")]
        public Sexo? Sexo { get; set; }

        [Required, Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required, Display(Name = "Celular")]
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
        
        [Required, DataType(DataType.Password), Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }

        [DataType(DataType.Password)]
        public string NovaSenha { get; set; }

        [Display(Name = "Confirma Senha"), DataType(DataType.Password), System.Web.Mvc.CompareAttribute("NovaSenha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmaSenha { get; set; }
        
    }
}