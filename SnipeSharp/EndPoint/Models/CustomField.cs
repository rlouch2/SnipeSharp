using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("fields", "")]
    public sealed class CustomField : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("db_column_name")]
        public string ColumnName { get; set; }

        [Field("format")]
        public string Format { get; set; }

        [Field("field_values")]
        public string FieldValuesRaw { get; set; }

        [Field("field_values_array")]
        public string[] FieldValues { get; set; }

        [Field("type")]
        public string Type { get; set; }

        [Field("required")]
        public bool? Required { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }
    }
}