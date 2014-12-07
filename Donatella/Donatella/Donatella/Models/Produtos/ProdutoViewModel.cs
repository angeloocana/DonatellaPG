using Donatella.Data.Entities;
using Donatella.Infrastructure.Mapping;

namespace Donatella.Models.Produtos
{
    public class ProdutoViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }
        public virtual string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public virtual decimal? PrecoDe { get; set; }
        public virtual decimal Preco { get; set; }
        public virtual string Categoria { get; set; }
        public bool Ativo { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Produto, ProdutoViewModel>()
                .ForMember(m => m.Categoria, opt =>
                    opt.MapFrom(u => u.Categoria.NomeCategoria))
                .ForMember(m => m.Ativo, opt =>
                    opt.MapFrom(u => u.DtInativacao == null));
        }
    }
}