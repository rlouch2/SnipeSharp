using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// GenericEndPointModel is a plain implementation of CommonEndPointModel.
    /// </summary>
    public sealed class GenericEndPointModel: CommonEndPointModel
    {
        /// <value>The internal Id of the object.</value>
        [Field("id", true)]
        public override int Id { get; protected set; }
        
        /// <value>The name of the object.</value>
        [Field("name")]
        public override string Name { get; set; }

        /// <value>The creation date of this object in Snipe-IT.</value>
        [Field("created_at")]
        public override DateTime? CreatedAt { get; protected set; }

        /// <value>The most recent date this object was modified in Snipe-IT.</value>
        [Field("updated_at")]
        public override DateTime? UpdatedAt { get; protected set; }
    }
}
