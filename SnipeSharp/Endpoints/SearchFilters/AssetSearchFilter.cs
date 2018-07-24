using SnipeSharp.Endpoints.Models;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.SearchFilters
{
    public class AssetSearchFilter : SearchFilter
    {
        [SerializeAs(Name = "order_number")]
        public string OrderNumber { get; set; }

        [SerializeAs(Name = "model_id")]
        public int? ModelId { get; set; }

        [SerializeAs(Name = "category_id")]
        public int? CategoryId { get; set; }

        [SerializeAs(Name = "manufacturer_id")]
        public Manufacturer Manufacturer { get; set; }

        [SerializeAs(Name = "company_id")]
        public int? CompanyId { get; set; }

        [SerializeAs(Name = "location_id")]
        public Location Location { get; set; }

        public string Status { get; set; }

        [SerializeAs(Name = "status_id")]
        public int? StatusId { get; set; }

    }
}
