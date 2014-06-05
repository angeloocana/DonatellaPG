using System.Linq;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Abstract
{
    public interface ICargoRepository
    {
        IQueryable<Cargo> Cargos { get; }
        void Salvar(Cargo cargo);

        void Excluir(int cargoId);
    }
}