using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models
{
    public class UsuarioFormViewModel : IHaveCustomMappings
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Foto { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string NovaSenha { get; set; }

        [Display(Name = "Confirma Senha"), DataType(DataType.Password), System.Web.Mvc.CompareAttribute("NovaSenha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmaSenha { get; set; }

        [Required]
        public string Cpf { get; set; }

        [DataType("CargoId"), Display(Name = "Cargo")]
        public int? CargoId { get; set; }

        [DataType("PerfilAcesso")]
        public IEnumerable<UsuarioPerfilAcessoViewModel> PerfilAcessoLista { get; set; }

        public IEnumerable<int> Perfis { get; set; }
        
        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Usuario, UsuarioFormViewModel>();
            configuration.CreateMap<UsuarioFormViewModel, Usuario>();

            configuration.CreateMap<CadastroViewModel, UsuarioFormViewModel>();
        }
    }
}