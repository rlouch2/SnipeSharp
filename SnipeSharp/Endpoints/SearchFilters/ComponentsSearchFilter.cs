using SnipeSharp.Endpoints.SearchFilters;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.SearchFilters
{
    class ComponentsSearchFilter : SearchFilter
    {
        [SerializeAs(Name = "order_number")]
        public string OrderNumber { get; set; }

        public bool Expand { get; set; }
    }
}

