using SnipeSharp.Endpoints.SearchFilters;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.SearchFilters
{
    class LicensesSearchFilter : SearchFilter
    {
        [SerializeAs(Name = "order_number")]
        public string OrderNumber { get; set; }

        public bool Expand { get; set; }
    }
}

