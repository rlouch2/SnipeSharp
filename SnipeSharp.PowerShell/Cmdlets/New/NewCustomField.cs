using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT custom field.</summary>
    /// <remarks>The New-CustomField cmdlet creates a new custom field object, but does not associate it with any field sets.</remarks>
    /// <example>
    ///   <code>New-CustomField -Name "Length"</code>
    ///   <para>Create a new custom field named "Length".</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(CustomField))]
    [OutputType(typeof(CustomField))]
    public class NewCustomField: PSCmdlet
    {
        /// <summary>
        /// The name of the field set.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The type of the field.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public CustomFieldElement Type { get; set; } = CustomFieldElement.Text;

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
        public string Format { get; set; } = "alpha_num";

        /// <summary>
        /// The values of this field.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyCollection]
        [AllowEmptyString]
        public string[] FieldValue { get; set; } = new string[0];

        /// <summary>
        /// Is the field encrypted?
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool IsFieldEncrypted { get; set; } = false;

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
        protected override void ProcessRecord()
        {
            var item = new CustomField {
                Name = this.Name,
                Type = this.Type,
                Format = this.Format,
                FieldValuesRaw = string.Join("\n", this.FieldValue),
                IsFieldEncrypted = this.IsFieldEncrypted,
                HelpText = this.HelpText
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ShowInCheckOutEmail)))
                item.ShowInCheckOutEmail = this.ShowInCheckOutEmail;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.CustomFields.Create(item));
        }
    }
}
