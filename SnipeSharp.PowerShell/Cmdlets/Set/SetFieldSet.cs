using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.EndPoint;
using SnipeSharp.PowerShell.BindingTypes;
using System.Collections.Generic;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    /// <summary>
    /// <para type="synopsis">Changes the properties of an existing Snipe-IT field set.</para>
    /// <para type="description">The Set-FieldSet cmdlet changes the properties of an existing Snipe-IT field set object.</para>
    /// </summary>
    /// <example>
    ///   <code>Set-FieldSet -Name "Peeler" -NewName "Potato Peeler"</code>
    ///   <para>Changes the name of fieldset "Peeler" to "Potato Peeler" to distinguish it from "Carrot Peeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(FieldSet))]
    [OutputType(typeof(FieldSet))]
    public class SetFieldSet: SetObject<FieldSet>
    {
        /// <summary>
        /// The new name for the field set.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// A list of fields to associate with this fieldset.
        /// </summary>
        [Parameter]
        [AllowEmptyCollection]
        public ObjectBinding<CustomField>[] Add { get; set; }

        /// <summary>
        /// A list of fields to associate with this fieldset, marked required.
        /// </summary>
        [Parameter]
        [AllowEmptyCollection]
        public ObjectBinding<CustomField>[] AddRequired { get; set; }

        /// <summary>
        /// A list of fields to disassociate with this fieldset.
        /// </summary>
        [Parameter]
        [AllowEmptyCollection]
        public ObjectBinding<CustomField>[] Remove { get; set; }

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
            if(Identity.IsNull)
            {
                WriteError(new ErrorRecord(Identity.Error, $"{nameof(FieldSet)} not found: {Identity.Query}", ErrorCategory.InvalidArgument, null));
                return;
            }

            // validate data before proceeding.
            if(Add != null && Add.Length > 0)
            {
                foreach(var field in Add)
                {
                    if(field.IsNull)
                    {
                        WriteError(new ErrorRecord(field.Error, $"{nameof(CustomField)} was not found: {field.Query}", ErrorCategory.InvalidArgument, null));
                        return;
                    }
                }
            }

            if(AddRequired != null && AddRequired.Length > 0)
            {
                foreach(var field in AddRequired)
                {
                    if(field.IsNull)
                    {
                        WriteError(new ErrorRecord(field.Error, $"{nameof(CustomField)} was not found: {field.Query}", ErrorCategory.InvalidArgument, null));
                        return;
                    }
                }
            }

            if(Remove != null && Remove.Length > 0)
            {
                foreach(var field in Remove)
                {
                    if(field.IsNull)
                    {
                        WriteError(new ErrorRecord(field.Error, $"{nameof(CustomField)} was not found: {field.Query}", ErrorCategory.InvalidArgument, null));
                        return;
                    }
                }
            }

            // populate record
            PopulateItem(Identity.Object);

            // modify fields
            if(Add != null && Add.Length > 0)
            {
                foreach(var field in Add)
                {
                    //TODO: error handling
                    ApiHelper.Instance.GetEndPoint<CustomField>().Associate(field.Object, Identity.Object, required: false);
                }
            }

            if(AddRequired != null && AddRequired.Length > 0)
            {
                foreach(var field in AddRequired)
                {
                    //TODO: error handling
                    ApiHelper.Instance.GetEndPoint<CustomField>().Associate(field.Object, Identity.Object, required: true);
                }
            }

            if(Remove != null && Remove.Length > 0)
            {
                foreach(var field in Remove)
                {
                    //TODO: error handling
                    ApiHelper.Instance.GetEndPoint<CustomField>().Disassociate(field.Object, Identity.Object);
                }
            }

            //TODO: error handling
            WriteObject(ApiHelper.Instance.GetEndPoint<FieldSet>().Update(Identity.Object));
        }
        
        /// <inheritdoc />
        protected override void PopulateItem(FieldSet item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = NewName;
        }
    }
}
