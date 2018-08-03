using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("fieldsets")]
    public sealed class FieldSet : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("fields")]
        public ResponseCollection<CustomField> Fields { get; set; }

        [Field("models")]
        public ResponseCollection<Model> Models { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
    }
}
