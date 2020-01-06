using System;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A custom field.
    /// Custom fields are in a many-to-many relationship with <see cref="FieldSet">Fieldsets</see>.
    /// </summary>
    [PathSegment("fields")]
    public sealed class CustomField : CommonEndPointModel, IUpdatable<CustomField>
    {
        /// <summary>Create a new CustomField object.</summary>
        public CustomField() { }

        /// <summary>Create a new CustomField object with the supplied ID, for use with updating.</summary>
        internal CustomField(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <value>Gets the internal column name.</value>
        [Field(DeserializeAs = "db_column_name")]
        public string ColumnName { get; private set; }

        /// <summary>
        /// <para>Gets/sets the format of the field, for example:</para>
        /// <list type="table">
        ///   <listheader>
        ///     <term>Format</term>
        ///     <description>Description</description>
        ///   </listheader>
        ///   <item>
        ///     <term>alpha</term>
        ///     <description>Only alphabetical characters.</description>
        ///   </item>
        ///   <item>
        ///     <term>alpha_dash</term>
        ///     <description>Only alphabetical characters and '-'.</description>
        ///   </item>
        ///   <item>
        ///     <term>numeric</term>
        ///     <description>Only numbers.</description>
        ///   </item>
        ///   <item>
        ///     <term>alpha_num</term>
        ///     <description>Only alphanumeric characters.</description>
        ///   </item>
        ///   <item>
        ///     <term>email</term>
        ///     <description>A string in an email format.</description>
        ///   </item>
        ///   <item>
        ///     <term>date</term>
        ///     <description>A date.</description>
        ///   </item>
        ///   <item>
        ///     <term>url</term>
        ///     <description>A url.</description>
        ///   </item>
        ///   <item>
        ///     <term>ip</term>
        ///     <description>Any IP address.</description>
        ///   </item>
        ///   <item>
        ///     <term>ipv4</term>
        ///     <description>Explicitly an IPv4 address.</description>
        ///   </item>
        ///   <item>
        ///     <term>ipv6</term>
        ///     <description>Explicitly an IPv6 address.</description>
        ///   </item>
        ///   <item>
        ///     <term>regex:/^[a-fA-F0-9]{2}:[a-fA-F0-9]{2}:[a-fA-F0-9]{2}:[a-fA-F0-9]{2}:[a-fA-F0-9]{2}:[a-fA-F0-9]{2}$/</term>
        ///     <description>A MAC Address. Other regex format follow the same "regex:/^.$/" format.</description>
        ///   </item>
        ///   <item>
        ///     <term>boolean</term>
        ///     <description>A boolean value.</description>
        ///   </item>
        /// </list>
        /// </summary>
        /// <value>Gets/sets the format of the field.</value>
        [Field("format")]
        public string Format { get; set; }

        /// <value>Gets/sets the raw value of any list type, separated by newlines.</value>
        [Field("field_values")]
        public string FieldValuesRaw { get; set; }

        /// <value>Gets/sets if the field is encrypted or not.</value>
        [Field("field_encrypted")]
        public bool? IsFieldEncrypted { get; set; }

        /// <value>Gets/sets if this field will be listed in emails sent to users.</value>
        [Field("show_in_email")]
        public bool? ShowInCheckOutEmail { get; set; }

        /// <value>Gets/sets the help text for the field.</value>
        [Field("help_text")]
        public string HelpText { get; set; }

        /// <value>Gets the values of a list type as an array.</value>
        /// <remarks>If <see cref="FieldValuesRaw" /> is updated, this will not be!</remarks>
        [Field(DeserializeAs = "field_values_array")]
        public string[] FieldValues { get; private set; }

        /// <value>Get/sets what the type of the element is.</value>
        [Field(DeserializeAs = "type", SerializeAs = "element")]
        public CustomFieldElement Type { get; set; }

        /// <value>Gets if this is a required field.</value>
        [Field("required")]
        public bool? IsRequired { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "deleted_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        public CustomField CloneForUpdate() => new CustomField(this.Id);

        /// <inheritdoc />
        public CustomField WithValuesFrom(CustomField other)
            => new CustomField(this.Id)
            {
                Name = other.Name,
                Format = other.Format,
                FieldValuesRaw = other.FieldValuesRaw,
                IsFieldEncrypted = other.IsFieldEncrypted,
                ShowInCheckOutEmail = other.ShowInCheckOutEmail,
                HelpText = other.HelpText,
                Type = other.Type,
                IsRequired = other.IsRequired
            };
    }
}
