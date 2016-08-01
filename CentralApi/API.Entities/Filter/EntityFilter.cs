using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Entities.Filter
{
    public abstract class EntityFilter<TEntity> : IEntityFilter<TEntity> where TEntity : class
    {
        public virtual IEnumerable<TEntity> Filer(IEnumerable<TEntity> instance)
        {
            return instance.Where(item => Validate(item));
        }

        public abstract bool Validate(TEntity instance);
    }
}