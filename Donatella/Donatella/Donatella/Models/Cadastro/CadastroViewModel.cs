using System;
using System.ComponentModel.DataAnnotations;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;
using Donatella.Models.Enums;
using Pol.Helpers;

namespace Donatella.Models
{
    public class CadastroViewModel : IHaveCustomMappings
    {
        public TipoTelaDeCadastro TipoTelaDeCadastro { get; set; }

        public int Id { get; set; }

        private string _foto;

        public string Foto
        {
            get
            {
                if (string.IsNullOrEmpty(_foto))
                    return "profile-noPhoto.jpg";

                if (_foto.StartsWith("FotoParticipantes/"))
                    return _foto;

                return "FotoParticipantes/" + _foto;
            }
            set { _foto = value; }
        }

        [Required]
        public string Nome { get; set; }

        [Required, DataType("CargoId"), Display(Name = "Cargo")]
        public int CargoId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Dt Nascimento")]
        public DateTime? DtNascimento { get; set; }

        [Required,
        EmailAddress(ErrorMessage = "Email inválido"),
        Display(Name = "E-mail")]
        public string Email { get; set; }

        [MaxLength(14)]
        public string Cpf { get; set; }

        public string Rg { get; set; }

        [Required, DataType("Sexo")]
        public Sexo? Sexo { get; set; }

        [Required, Display(Name = "Telefone")]
        public string TelResidencial { get; set; }
        
        [Required, Display(Name = "Celular")]
        public string TelCelular { get; set; }

        public Endereco Endereco { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Nova senha"), StringLength(30, ErrorMessage = "Nova Senha deve ter de {2} à {1} caracteres", MinimumLength = 6)]
        public string NovaSenha { get; set; }

        [Required, Display(Name = "Confirmar a senha"), DataType(DataType.Password), System.Web.Mvc.CompareAttribute("NovaSenha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmaSenha { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Usuario, CadastroViewModel>()
                .ForMember(m => m.TelCelular, opt =>
                    opt.MapFrom(u => "(" + u.TelCelularDdd + ") " + u.TelCelular))
                .ForMember(m => m.TelResidencial, opt =>
                    opt.MapFrom(u => "(" + u.TelResidencialDdd + ") " + u.TelResidencial));

            configuration.CreateMap<CadastroViewModel, Usuario>()
                .ForMember(m => m.Endereco, opt =>
                    opt.MapFrom(u => (Endereco)null))
                    .ForMember(m => m.TelCelularDdd, opt =>
                    opt.MapFrom(u => TextoHelpers.GetDdd(u.TelCelular)))
                    .ForMember(m => m.TelResidencialDdd, opt =>
                    opt.MapFrom(u => TextoHelpers.GetDdd(u.TelResidencial)))

                .ForMember(m => m.TelCelular, opt =>
                    opt.MapFrom(u => TextoHelpers.GetTelefoneSemDdd(u.TelCelular)))
                    .ForMember(m => m.TelResidencial, opt =>
                    opt.MapFrom(u => TextoHelpers.GetTelefoneSemDdd(u.TelResidencial)));
        }
    }
}