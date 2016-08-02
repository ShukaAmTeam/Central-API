using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Entities.Filtering
{
    public abstract class EntityFilter<TEntity> : IEntityFilter<TEntity> where TEntity : class
    {
        public abstract IQueryable<TEntity> Filer(IQueryable<TEntity> instance);

        public abstract bool Validate(TEntity instance);
    }
}