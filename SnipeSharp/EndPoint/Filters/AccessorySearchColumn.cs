using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// Columns an Accessory search can be sorted on.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessorySearchColumn
    {
        /// <summary>The internal Id number.</summary>
        [EnumMember(Value = "id")]
        Id,
        /// <summary>The name of the accessory.</summary>
        [EnumMember(Value = "name")]
        Name,
        /// <summary>The model number of the accessory.</summary>
        [EnumMember(Value = "model_number")]
        ModelNumber,
        /// <summary>The category of the accessory.</summary>
        /// <remarks>This value, while there is special code for it in the API, does not actually work as it is not a listed sortable column for Accessories.</remarks>
        [EnumMember(Value = "category")]
        Category,
        /// <summary>The creation date of the accessory.</summary>
        [EnumMember(Value = "created_at")]
        CreatedAt,
        /// <summary>The minimum amount of accessories left before a warning is given.</summary>
        [EnumMember(Value = "min_amt")]
        MinimumQuantity,
        /// <summary>The Id of the Company.</summary>
        [EnumMember(Value = "company_id")]
        CompanyId,
        /// <summary>The Company that owns the Asset.</summary>
        /// <remarks>
        /// <para>This value, while there is special code for it in the API, does not actually work as it is not a listed sortable column for Accessories.</para>
        /// <para>Use <see cref="CompanyId">CompanyId</see> instead.</para>
        /// </remarks>
        [EnumMember(Value = "company")]
        Company
    }
}
