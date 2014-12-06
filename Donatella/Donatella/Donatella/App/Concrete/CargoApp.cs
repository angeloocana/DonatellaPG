using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models;
using Donatella.Helpers;
using Donatella.Models.Cargos;
using Donatella.Models.Enums;

namespace Donatella.App.Concrete
{
    public class CargoApp : ICargoApp
    {
        private readonly IRepository<Cargo> _cargoRepository;

        public CargoApp(IRepository<Cargo> cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public Dictionary<int, string> Combo()
        {
            return (from x in _cargoRepository.Get()
                    where x.DtInativacao == null
                    orderby x.NomeCargo
                    select new
                    {
                        x.NomeCargo,
                        x.Id
                    }).ToDictionary(x => x.Id, x => x.NomeCargo);
        }

        public Cargo FindByNome(string nome)
        {
            return _cargoRepository.Get().FirstOrDefault(m => m.NomeCargo == nome);
        }

        public IEnumerable<Cargo> Cargos()
        {
             return _cargoRepository.Get(); 
        }

        public CargoViewModel Cargo(int id)
        {
            var cargo = _cargoRepository.Get(id);
            return Mapper.Map<CargoViewModel>(cargo);
        }

        public void Salvar(CargoViewModel cargo)
        {
            var dbCargo = cargo.Id == 0 ? new Cargo()
                : _cargoRepository.Get(cargo.Id);

            if (dbCargo == null)
                throw new Exception("Cargo não pode ser alterado, pois não existe no banco.");

            dbCargo.NomeCargo = cargo.NomeCargo;

            _cargoRepository.AddOrUpdate(dbCargo);
            _cargoRepository.Commit();
        }

        public void Excluir(int cargoId)
        {
            var cargo = _cargoRepository.Get(cargoId);
            if (cargo == null) throw new Exception("Cargo não existe!");

            if (cargo.Usuarios.Any())
                throw new Exception("Cargo não pode ser excluido, pois possui usuários vinculados!");

            _cargoRepository.Delete(cargo);
            _cargoRepository.Commit();
        }
    }
}