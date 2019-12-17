using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the order of fields in an existing Snipe-IT field set.</summary>
    /// <remarks>The Set-FieldSetOrder cmdlet changes the order of custom fields in an existing Snipe-IT field set object.</remarks>
    /// <example>
    ///   <code>Set-FieldSetOrder -Name "Potato Peeler" -Order "Length", "Width", "Handle Size"</code>
    ///   <para>Changes the order of fields in the fieldset "Potato Peeler" to  "Length, Width, Handle Size".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, "FieldSetOrder")]
    [OutputType(typeof(FieldSet))]
    public class SetFieldSetOrder: SetObject<FieldSet, ObjectBinding<FieldSet>>
    {
        /// <summary>
        /// The fields of the field set, in the order desired.
        /// </summary>
        [Parameter(Mandatory = true)]
        [Alias("Fields")]
        public ObjectBinding<CustomField>[] Order { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.ByInternalId):
                    Identity = ObjectBinding<FieldSet>.FromId(Id);
                    break;
                case nameof(ParameterSets.ByName):
                    Identity = ObjectBinding<FieldSet>.FromName(Name);
                    break;
                case nameof(ParameterSets.ByIdentity):
                    break;
            }
            if(!this.GetSingleValue(Identity, out var identity))
                return;

            var orderedFields = new List<CustomField>();
            foreach(var field in Order)
            {
                if (!this.GetSingleValue(field, out var fieldItem))
                    return;
                orderedFields.Add(fieldItem);
            }

            WriteObject(ApiHelper.Instance.CustomFields.Reorder(identity, orderedFields));
        }

        /// <inheritdoc />
        protected override bool PopulateItem(FieldSet item)
        {
            return false;
        }
    }
}
