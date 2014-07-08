using System.Linq;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Delete(int id);

        TEntity Get(int id);

        TEntity First();
        IQueryable<TEntity> Get();
        void Update(TEntity obj);
    }
}
