using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT custom field.</summary>
    /// <remarks>The Set-CustomField cmdlet changes the properties of an existing Snipe-IT custom field object.</remarks>
    /// <example>
    ///   <code>Set-CustomField -Name "Length" -Format "numeric"</code>
    ///   <para>Changes the format of field "Length" to "numeric".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(CustomField))]
    [OutputType(typeof(CustomField))]
    public class SetCustomField: SetObject<CustomField, ObjectBinding<CustomField>>
    {
        /// <summary>
        /// The name of the field set.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <summary>
        /// The type of the field.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public CustomFieldElement Type { get; set; }

        /// <summary>
        /// <para>The format of the field, for example:</para>
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
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Format { get; set; }

        /// <summary>
        /// The values of this field.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyCollection]
        [AllowEmptyString]
        public string[] FieldValue { get; set; }

        /// <summary>
        /// Is the field encrypted?
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool IsFieldEncrypted { get; set; }

        /// <summary>
        /// Should the field be listed in emails sent to users?
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool ShowInCheckOutEmail { get; set; }

        /// <summary>
        /// The help text for the field in the UI.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string HelpText { get; set; } = string.Empty;

        /// <inheritdoc />
        protected override bool PopulateItem(CustomField item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
                item.Type = this.Type;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Format)))
                item.Format = this.Format;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FieldValue)))
                item.FieldValuesRaw = this.FieldValue == null ? string.Empty : string.Join("\n", this.FieldValue);
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsFieldEncrypted)))
                item.IsFieldEncrypted = this.IsFieldEncrypted;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(HelpText)))
                item.HelpText = this.HelpText ?? string.Empty;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ShowInCheckOutEmail)))
                item.ShowInCheckOutEmail = this.ShowInCheckOutEmail;
            return true;
        }
    }
}
