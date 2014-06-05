using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface ICargoRepository
    {
        IQueryable<Cargo> Cargos { get; }
        void SalvarCargo(Cargo Cargo);
    }
}