using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnipeSharp.EndPoint.Models
{
    public abstract class CommonEndPointModel: ApiObject
    {
        public abstract int Id { get; set; }
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