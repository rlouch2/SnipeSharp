using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// Columns a user search can be sorted on.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ManufacturerSearchColumn
    {
        /// <summary>The date the manufacturer was created.</summary>
        [EnumMember(Value = "created_at")]
        CreatedAt,
        /// <summary>The date the manufacturer was deleted.</summary>
        [EnumMember(Value = "deleted_at")]
        DeletedAt,
        /// <summary>The date the manufacturer was last updated.</summary>
        [EnumMember(Value = "updated_at")]
        UpdatedAt,
        /// <summary>How many assets were made by the manufacturer.</summary>
        [EnumMember(Value = "assets_count")]
        AssetsCount,
        /// <summary>How many licenses were made by the manufacturer.</summary>
        [EnumMember(Value = "licenses_count")]
        LicensesCount,
        /// <summary>How many components were made by the manufacturer.</summary>
        [EnumMember(Value = "components_count")]
        ComponentsCount,
        /// <summary>How many consumables were made by the manufacturer.</summary>
        [EnumMember(Value = "consumables_count")]
        ConsumablesCount,
        /// <summary>The manufacturer's support email address.</summary>
        [EnumMember(Value = "support_email")]
        SupportEmailAddress,
        /// <summary>The manufacturer's support phone number.</summary>
        [EnumMember(Value = "support_phone")]
        SupportPhoneNumber,
        /// <summary>The manufacturer's support URL.</summary>
        [EnumMember(Value = "support_url")]
        SupportUrl,
        /// <summary>The manufactuerer's website URL.</summary>
        [EnumMember(Value = "url")]
        Url,
        /// <summary>The name of the manufacturer.</summary>
        [EnumMember(Value = "name")]
        Name,
        /// <summary>The image URI.</summary>
        [EnumMember(Value = "image")]
        Image,
        /// <summary>The internal Id number.</summary>
        [EnumMember(Value = "id")]
        Id
    }
}