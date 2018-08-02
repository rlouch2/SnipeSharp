using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

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
        public abstract int Id { get; set; }
        
        /// <summary>
        /// The name of the object.
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// The creation date of this object in Snipe-IT.
        /// </summary>
        public abstract DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The most recent date this object was modified in Snipe-IT.
        /// </summary>
        public abstract DateTime? UpdatedAt { get; set; }

        /// <inheritdoc />
        public override string ToString()
            => Name ?? Id.ToString();
    }
}
