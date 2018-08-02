using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("fieldsets")]
    public class FieldSet : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }

        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("fields")]
        public ResponseCollection<CustomField> Fields { get; set; }

        [Field("models")]
        public ResponseCollection<Model> Models { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }
    }
}
