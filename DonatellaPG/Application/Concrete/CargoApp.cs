using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Concrete
{
    public class CargoApp : AppBase, ICargoApp
    {
        private IRepositoryBase<Cargo> _cargoRepository;
        public CargoApp(IRepositoryBase<Cargo> cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        public IEnumerable<Cargo> Cargos
        {
            get { return _cargoRepository.Get(); }
        }

        public void Salvar(Cargo cargo)
        {
            BeginTransaction();

            var dbCargo = cargo.CargoId == 0 ? new Cargo()
                : _cargoRepository.Get(cargo.CargoId);
        
            if(dbCargo == null)
                throw new Exception("Cargo não pode ser alterado, pois não existe no banco.");

            dbCargo.NomeCargo = cargo.NomeCargo;

            if (dbCargo.CargoId == 0)
                _cargoRepository.Add(dbCargo);

            Commint();
        }

        public void Excluir(int cargoId)
        {
            var cargo = _cargoRepository.Get(cargoId);
            if (cargo == null) throw new Exception("Cargo não existe!");

            if (cargo.Funcionarios.Any())
                throw new Exception("Cargo não pode ser excluido, pois possui funcionarios vinculados!");

            BeginTransaction();
            _cargoRepository.Delete(cargo);
            Commint();
        }
    }
}
