using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp;
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
            if(!Identity.HasValue)
            {
                WriteError(new ErrorRecord(Identity.Error, $"{nameof(FieldSet)} not found: {Identity.Query}", ErrorCategory.InvalidArgument, null));
                return;
            }
            if(Identity.Value.Count > 1)
            {
                WriteError(new ErrorRecord(Identity.Error, $"More than one {nameof(FieldSet)} was found: {Identity.Query}", ErrorCategory.InvalidArgument, null));
                return;
            }

            var orderedFields = new List<CustomField>();
            foreach(var field in Order)
            {
                if(!field.HasValue)
                {
                    WriteError(new ErrorRecord(field.Error, $"{nameof(CustomField)} was not found: {field.Query}", ErrorCategory.InvalidArgument, null));
                    return;
                }
                if(field.Value.Count > 1)
                {
                    WriteError(new ErrorRecord(field.Error, $"More than one {nameof(CustomField)} was found: {field.Query}", ErrorCategory.InvalidArgument, null));
                    return;
                }
                orderedFields.Add(field.Value[0]);
            }

            WriteObject(ApiHelper.Instance.GetEndPoint<CustomField>().Reorder(Identity.Object, orderedFields));
        }
        
        /// <inheritdoc />
        protected override void PopulateItem(FieldSet item)
        {
            // nop, not called
        }
    }
}
