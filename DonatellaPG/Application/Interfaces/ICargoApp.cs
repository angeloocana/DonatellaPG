using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICargoApp
    {
        IEnumerable<Cargo> Cargos { get; }
        void Salvar(Cargo cargo);

        void Excluir(int cargoId);
    }
}