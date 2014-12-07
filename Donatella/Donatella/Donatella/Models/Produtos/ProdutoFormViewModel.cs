using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models.Produtos
{
    public class ProdutoFormViewModel : IHaveCustomMappings
    {
        [HiddenInput]
        public int Id { get; set; }

        [StringLength(150)]
        [Required]
        [Display(Name = "Produto")]
        public virtual string NomeProduto { get; set; }

        public string Descricao { get; set; }
        public virtual decimal? PrecoDe { get; set; }
        [Required]
        public virtual decimal Preco { get; set; }

        [DataType("CategoriaId"), Display(Name = "Categoria"), Required]
        public virtual int? CategoriaId { get; set; }

        public bool Ativo { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Produto, ProdutoFormViewModel>()
                .ForMember(m => m.Ativo, opt =>
                    opt.MapFrom(u => u.DtInativacao == null));

            configuration.CreateMap<ProdutoFormViewModel, Produto>()
               .ForMember(m => m.DtInativacao, opt =>
                   opt.MapFrom(u => u.Ativo ? (DateTime?)null : DateTime.Now));
        }
    }
}