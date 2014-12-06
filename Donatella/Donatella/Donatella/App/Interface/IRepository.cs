using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Data.Entities;

namespace Donatella.App.Interface
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity obj);
        void AddAll(IEnumerable<TEntity> obj);
        void DeleteAll(IEnumerable<TEntity> obj);
        void Delete(TEntity obj);
        void Delete(int id);

        TEntity Get(int id);

        TEntity First();
        IQueryable<TEntity> Get();
        void Update(TEntity obj);

        void Commit();

        void AddOrUpdate(TEntity obj);
        void Inativar(int id);
    }
}