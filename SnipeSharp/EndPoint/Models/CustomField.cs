using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("fields")]
    public sealed class CustomField : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name", true)]
        public override string Name { get; set; }

        [Field("db_column_name")]
        public string ColumnName { get; set; }

        [Field("format", true)]
        public string Format { get; set; }

        [Field("field_values", true)]
        public string FieldValuesRaw { get; set; }

        [Field("field_encrypted", true)]
        public bool? IsFieldEncrypted { get; set; }

        [Field("show_in_email", true)]
        public bool? ShowInCheckOutEmail { get; set; }

        [Field("help_text", true)]
        public string HelpText { get; set; }

        [Field("field_values_array")]
        public string[] FieldValues { get; set; }

        [Field("type", "element")]
        public CustomFieldElement Type { get; set; }

        [Field("required")]
        public bool? IsRequired { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomFieldElement
    {
        [EnumMember(Value = "list")]
        List,
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "textarea")]
        TextArea
    }
}
