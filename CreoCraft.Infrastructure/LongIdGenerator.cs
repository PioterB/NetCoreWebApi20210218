using System;
using CreoCraft.Domain;

namespace CreoCraft.Infrastructure
{
    public class LongIdGenerator : IIdGenerator<Guid>
    {
        public Guid Next()
        {
            return Guid.NewGuid();
        }
    }
}