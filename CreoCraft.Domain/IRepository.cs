using System.Collections.Generic;

namespace CreoCraft.Domain
{
    public interface IRepository<TKey, TEntity> where TEntity: class, IEntity<TKey>
    {
        IEnumerable<TEntity> Get();

        TEntity Get(TKey id);

        void Add(TEntity item);

        void Remove(TKey id);
    }
}