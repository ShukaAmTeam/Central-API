using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using API.Entities.Filter;

namespace API
{
    public class ListParametersBinding : HttpParameterBinding
    {
        public ListParametersBinding(HttpParameterDescriptor descriptor) : base(descriptor) { }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext context, CancellationToken cancellationToken)
        {
            if (!context.Request.Method.Method.Equals("GET")) { return Task.FromResult<object>(null); }

            var queryParams = context.Request.GetQueryNameValuePairs().Where(q => !string.IsNullOrEmpty(q.Value));

            // limit and offset
            int? limit = null;
            if (queryParams.Any(kvp => kvp.Key == "limit"))
                limit = queryParams.Where(kvp => kvp.Key == "limit").Select(kvp => int.Parse(kvp.Value)).FirstOrDefault();

            int? offset = null;
            if (queryParams.Any(kvp => kvp.Key == "offset"))
                offset = queryParams.Where(kvp => kvp.Key == "offset").Select(kvp => int.Parse(kvp.Value)).FirstOrDefault();

            // load filters
            var filters = new List<ListOptionsFilter>();

            // load contains filters
            filters.AddRange(queryParams.Where(kvp => kvp.Key.ToLower().StartsWith("filter."))
               .Select(kvp => new ListOptionsFilter
               {
                   Key = kvp.Key.ToLower().Replace("filter.", string.Empty),
                   Values = kvp.Value.Split(','),
                   Type = OptionsFilterTypes.Contains
               }));

            // load range filters
            var queryStr = context.Request.RequestUri.Query.Replace("?", "").Replace("filter[", "").Replace("]", "").Split('&');
            var geFilters = queryStr.Where(s => s.Contains("%3E")).Select(x => x.Split(new string[] { "%3E" }, StringSplitOptions.None)).Where(i => !string.IsNullOrEmpty(i[1])).ToDictionary(i => i[0], i => i[1]);
            var leFilters = queryStr.Where(s => s.Contains("%3C")).Select(x => x.Split(new string[] { "%3C" }, StringSplitOptions.None)).Where(i => !string.IsNullOrEmpty(i[1])).ToDictionary(i => i[0], i => i[1]);

            filters.AddRange(geFilters.Select(f => new ListOptionsFilter
            {
                Key = f.Key,
                Values = new string[] { f.Value },
                Type = OptionsFilterTypes.GreaterThanOrEqual
            }));

            filters.AddRange(leFilters.Select(f => new ListOptionsFilter
            {
                Key = f.Key,
                Values = new string[] { f.Value },
                Type = OptionsFilterTypes.LessThanOrEqual
            }));

            var listOptionsEntity = new Options(limit, offset, filters);

            SetValue(context, listOptionsEntity);

            return Task.FromResult<object>(null);
        }
    }
}