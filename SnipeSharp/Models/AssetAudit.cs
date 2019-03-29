using System;
using SnipeSharp.EndPoint;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// ApiObject for submitting Asset audits.
    /// </summary>
    /// <seealso cref="EndPointExtensions.Audit(EndPoint{Asset}, Asset, Location, DateTime?, string)"/>
    public sealed class AssetAudit : ApiObject
    {
        /// <summary>
        /// The asset tag of the Asset being audited.
        /// </summary>
        /// <remarks>This field is required.</remarks>
        [Field("asset_tag", Converter = CommonModelConverter, IsRequired = true)]
        public Asset Asset { get; set; }

        /// <summary>
        /// The audit location.
        /// </summary>
        /// <remarks>This field will not be filled by the API.</remarks>
        [Field(SerializeAs = "location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// The next scheduled audit date.
        /// </summary>
        [Field("next_audit_date", Converter = DateTimeConverter)]
        public DateTime? NextAuditDate { get; set; }

        /// <summary>
        /// Notes for the audit log.
        /// </summary>
        [Field("note")]
        public string Note { get; set; }
    }
}
