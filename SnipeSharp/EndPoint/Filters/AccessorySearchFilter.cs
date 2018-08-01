using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.Serialization.FieldConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

/// <summary>
/// The base class for all SearchFilter objects.  These properties are common to any filter we want to do on a get request for all endpoints.
/// </summary>
namespace SnipeSharp.EndPoint.Filters
{
    public sealed class AccessorySearchFilter : ISearchFilter<AccessorySearchColumn>
    {
        [Field("limit", true)]
        public int? Limit { get; set; }

        [Field("offset", true)]
        public int? Offset { get; set; }

        [Field("search", true)]
        public string Search { get; set; }

        [Field("sort", true)]
        public AccessorySearchColumn SortColumn { get; set; }

        [Field("order", true)]
        public SearchOrder Order { get; set; }

        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("category_id", true, converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("manufacturer_id", true, converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        public AccessorySearchFilter()
        {
        }

        public AccessorySearchFilter(string searchString)
        {
            Search = searchString;
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessorySearchColumn
    {
        [EnumMember(Value = "id")]
        Id,
        [EnumMember(Value = "name")]
        Name,
        [EnumMember(Value = "model_number")]
        ModelNumber,
        [EnumMember(Value = "eol")]
        Eol, //TODO: name
        [EnumMember(Value = "notes")]
        Notes,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "min_amt")]
        MinimumQuantity,
        [EnumMember(Value = "company_id")]
        Company
    }
}
