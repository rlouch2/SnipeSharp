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
        /// <value>The internal Id of the object.</value>
        [Field("id", true)]
        public abstract int Id { get; protected set; }
        
        /// <value>The name of the object.</value>
        [Field("name")]
        public abstract string Name { get; set; }

        /// <value>The creation date of this object in Snipe-IT.</value>
        [Field("created_at")]
        public abstract DateTime? CreatedAt { get; protected set; }

        /// <value>The most recent date this object was modified in Snipe-IT.</value>
        [Field("updated_at")]
        public abstract DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        public override string ToString()
            => Name ?? Id.ToString();
    }
}
