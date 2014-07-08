﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;


namespace Application.Concrete
{
    public class EFIngredienteApp : IIngredienteApp
    {
        private EFDbContext _dbContext;

        public EFIngredienteApp()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Ingrediente> Ingredientes
        {
            get { return _dbContext.Ingredientes; }
        }

        public void SalvarIngrediente(Ingrediente ingrediente)
        {
            var dbIngrediente = ingrediente.IngredienteId == 0 ? new Ingrediente()
                : _dbContext.Ingredientes.Find(ingrediente.IngredienteId);

            if (dbIngrediente == null)
                throw new Exception("Ingrediente não pode ser alterado, pois não existe no banco.");

            dbIngrediente.NomeIngrediente = ingrediente.NomeIngrediente;

            if (dbIngrediente.IngredienteId == 0)
                _dbContext.Ingredientes.Add(dbIngrediente);

            _dbContext.SaveChanges();
        }
    }
}