using System.Collections.Generic;
using System.Linq;
using CreoCraft.Domain;

namespace CreoCraft.Infrastructure
{
    public class InMemoryRepository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey>
    {
        private readonly IDictionary<TKey, TEntity> _memory = new Dictionary<TKey, TEntity>();

        public IEnumerable<TEntity> Get()
        {
            return _memory.Values.ToArray();
        }

        public TEntity Get(TKey id)
        {
            return _memory[id];
        }

        public void Add(TEntity item)
        {
            _memory.Add(item.Id, item);
        }

        public void Remove(TKey id)
        {
            _memory.Remove(id);
        }
    }
}