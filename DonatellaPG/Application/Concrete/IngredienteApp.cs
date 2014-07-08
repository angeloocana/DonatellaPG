using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;


namespace Application.Concrete
{
    public class IngredienteApp : AppBase, IIngredienteApp
    {
        private IRepositoryBase<Ingrediente> _ingredienteRepository;
        public IngredienteApp(IRepositoryBase<Ingrediente> ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }
        public IEnumerable<Ingrediente> Ingredientes
        {
            get { return _ingredienteRepository.Get(); }
        }

        public void SalvarIngrediente(Ingrediente ingrediente)
        {
            BeginTransaction();

            var dbIngrediente = ingrediente.IngredienteId == 0 ? new Ingrediente()
                : _ingredienteRepository.Get(ingrediente.IngredienteId);

            if (dbIngrediente == null)
                throw new Exception("Ingrediente não pode ser alterado, pois não existe no banco.");

            dbIngrediente.NomeIngrediente = ingrediente.NomeIngrediente;

            if (dbIngrediente.IngredienteId == 0)
                _ingredienteRepository.Add(dbIngrediente);

            Commint();
        }
    }
}
