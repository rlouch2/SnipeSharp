using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// CommonEndPointModel is an ApiObject associated with an Api EndPoint.
    /// </summary>
    public abstract class CommonEndPointModel: ApiObject
    {
        /// <summary>
        /// The internal Id of the object.
        /// </summary>
        [Field("id", true)]
        public abstract int Id { get; protected set; }
        
        /// <summary>
        /// The name of the object.
        /// </summary>
        [Field("name")]
        public abstract string Name { get; set; }

        /// <summary>
        /// The creation date of this object in Snipe-IT.
        /// </summary>
        [Field("created_at")]
        public abstract DateTime? CreatedAt { get; protected set; }

        /// <summary>
        /// The most recent date this object was modified in Snipe-IT.
        /// </summary>
        [Field("updated_at")]
        public abstract DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        public override string ToString()
            => Name ?? Id.ToString();
    }
}
