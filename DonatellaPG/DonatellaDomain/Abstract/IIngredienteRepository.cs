using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface IIngredienteRepository
    {
        IQueryable<Ingrediente> Ingredientes { get; }
        void SalvarIngrediente(Ingrediente ingrediente);
    }
}