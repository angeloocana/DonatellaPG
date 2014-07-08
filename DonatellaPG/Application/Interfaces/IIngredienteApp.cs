using System.Collections.Generic;
using System.Linq;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IIngredienteApp
    {
        IEnumerable<Ingrediente> Ingredientes { get; }
        void SalvarIngrediente(Ingrediente ingrediente);
    }
}