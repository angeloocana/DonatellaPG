using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFCargoRepository : ICargoRepository
    {
        private EFDbContext _dbContext;

        public EFCargoRepository()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Cargo> Cargos
        {
            get { return _dbContext.Cargos; }
        }

        public void SalvarCargo(Cargo cargo)
        {
            var dbCargo = cargo.CargoId == 0 ? new Cargo()
                : _dbContext.Cargos.Find(cargo.CargoId);
        
            if(dbCargo == null)
                throw new Exception("Cargo não pode ser alterado, pois não existe no banco.");

            dbCargo.NomeCargo = cargo.NomeCargo;

            if (dbCargo.CargoId == 0)
                _dbContext.Cargos.Add(dbCargo);

            _dbContext.SaveChanges();
        }
    }
}
