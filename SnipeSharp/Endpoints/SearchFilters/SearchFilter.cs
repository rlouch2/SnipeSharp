using SnipeSharp.Common;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RestSharp.Serializers;

/// <summary>
/// The base class for all SearchFilter objects.  These properties are common to any filter we want to do on a get request for all endpoints.
/// </summary>
namespace SnipeSharp.Endpoints.SearchFilters
{
    public class SearchFilter : ISearchFilter
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }

        public Dictionary<string, string> QueryParameters {
            get {
                var values = new Dictionary<string, string>();
                foreach(var property in this.GetType().GetProperties())
                {
                    var value = property.GetValue(this)?.ToString();
                    if(value == null)
                        continue;
                    values[property.GetCustomAttribute<SerializeAsAttribute>()?.Name ?? property.Name.ToLower()] = value;
                }
                return values;
            }
        }
    }
}

