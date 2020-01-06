using System;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// CommonEndPointModel is an ApiObject associated with an Api EndPoint.
    /// </summary>
    public abstract class CommonEndPointModel: ApiObject
    {
        /// <value>The internal Id of the object.</value>
        [Field("id")]
        public abstract int Id { get; set; }

        /// <value>The name of the object.</value>
        [Field(DeserializeAs = "name")]
        public abstract string Name { get; set; }

        /// <value>The creation date of this object in Snipe-IT.</value>
        [Field(DeserializeAs = "created_at", Converter = FieldConverter.DateTimeConverter)]
        public abstract DateTime? CreatedAt { get; protected set; }

        /// <value>The most recent date this object was modified in Snipe-IT.</value>
        [Field(DeserializeAs = "updated_at", Converter = FieldConverter.DateTimeConverter)]
        public abstract DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        public override string ToString()
            => Name ?? Id.ToString();
    }
}
