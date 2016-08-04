using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http.OData.Query;

namespace API.Entities.Filtering
{
    public class ODataFilter<TEntity> : EntityFilter<TEntity> where TEntity : class
    {
        private ODataQueryOptions<TEntity> _options;
        public ODataFilter(ODataQueryOptions<TEntity> options)
        {
            _options = options;
        }
        public override IQueryable<TEntity> Filer(IQueryable<TEntity> instance)
        {
            return _options.ApplyTo(instance) as IQueryable<TEntity>;
        }

        public override bool Validate(TEntity instance)
        {
            throw new NotImplementedException();
        }
    }
}