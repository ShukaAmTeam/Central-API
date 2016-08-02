using System.Linq;
using System.Collections.Generic;

namespace API.Entities.Filtering
{
    public class Options
    {
        public int? Limit { get; }

        public int? Offset { get; }

        public IEnumerable<ListOptionsFilter> Filters { get; }

        public Options()
        {
            Limit = int.MaxValue;
            Offset = 0;
            Filters = new List<ListOptionsFilter>();
        }

        public Options(int? limit, int? offset)
        {
            Limit = limit;
            Offset = offset;
            Filters = new List<ListOptionsFilter>();
        }

        public Options(int? limit, int? offset, IEnumerable<ListOptionsFilter> filters)
        {
            Limit = limit;
            Offset = offset;
            Filters = filters;
        }

        #region remove later

        public IEnumerable<ListOptionsFilter> GetFilters(string filterKey)
        {
            return Filters?.Where(f => f.Key.Equals(filterKey, System.StringComparison.OrdinalIgnoreCase));
        }
        public string[] GetFilterValues(string filterKey)
        {
            return Filters?.FirstOrDefault(f => f.Key.Equals(filterKey, System.StringComparison.OrdinalIgnoreCase))?.Values;
        }
        public string GetFilterValue(string filterKey)
        {
            var values = GetFilterValues(filterKey);
            return values?.Length > 0 ? values[0] : string.Empty;
        }
        public int? GetFilterIntValue(string filterKey)
        {
            int value;
            if (int.TryParse(GetFilterValue(filterKey), out value))
            {
                return value;
            }
            return null;
        }

        #endregion remove later
    }

    public class ListOptionsFilter
    {
        public string Key { get; set; }

        public string[] Values { get; set; }

        public OptionsFilterTypes Type { get; set; }
    }

    public enum OptionsFilterTypes
    {
        Contains,
        GreaterThanOrEqual,
        LessThanOrEqual
    }
}
