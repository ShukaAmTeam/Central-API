using System.Collections.Generic;
using System.Linq;

namespace API.Entities.Filter
{
    public interface IEntityFilter<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> Filer(IEnumerable<TEntity> instance);
        bool Validate(TEntity instance);
    }
}