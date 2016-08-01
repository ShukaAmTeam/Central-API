using System.Collections.Generic;
using System.Linq;

namespace API.Entities.Filter
{
    public class OptionalFilter<TEntity> : EntityFilter<TEntity> where TEntity : class
    {
        public int? Limit { get; }

        public int? Offset { get; }

        public override IEnumerable<TEntity> Filer(IEnumerable<TEntity> instance)
        {
            return instance
                .Skip(Offset ?? 0)
                .Take(Limit ?? 1000);
        }

        public override bool Validate(TEntity instance)
        {
            throw new System.NotImplementedException();// ToDo Stex linuma @ndhanur logic sax typeri hamar.
        }
    }
}