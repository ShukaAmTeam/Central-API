using System.Collections.Generic;
using System.Linq;

namespace API.Entities.Filtering
{
    public interface IEntityFilter<TEntity> where TEntity:class
    {
        IQueryable<TEntity> Filer(IQueryable<TEntity> instance);
        bool Validate(TEntity instance);
    }
}