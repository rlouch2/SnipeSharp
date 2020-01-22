using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// Generic base class for Set* Cmdlets.
    /// </summary>
    /// <typeparam name="TObject">Type of object to set.</typeparam>
    /// <typeparam name="TBinding">The type of the Identity property.</typeparam>
    public abstract class SetObject<TObject, TBinding>: PSCmdlet
        where TObject: CommonEndPointModel, new()
        where TBinding: ObjectBinding<TObject>
    {
        /// <summary>
        /// Parameter sets supported by Set* cmdlets.
        /// </summary>
        internal enum ParameterSets
        {
            ByIdentity,
            ByName,
            ByInternalId
        }

        /// <summary>The identity of the item to update.</summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByIdentity))]
        [ValidateIdentityNotNull]
        public TBinding Identity { get; set; }

        /// <summary>The name of the item to update.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(ParameterSets.ByName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>The id of the item to update.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(ParameterSets.ByInternalId))]
        public int Id { get; set; }

        /// <summary>If present, write the response from the Api to the pipeline.</summary>
        [Parameter]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        ///     <para>If present, completely overwrite all properties the remote object with the current or provided values.</para>
        ///     <para>The provided object will be fetched, its values updated with the ones provided to the cmdlet, then all values given to the API.</para>
        /// </summary>
        [Parameter]
        public SwitchParameter Overwrite { get; set; }

        /// <summary>
        /// Populate the fields of the item.
        /// </summary>
        /// <param name="item">The item to populate.</param>
        /// <returns>True if the operation should proceed.</returns>
        protected abstract bool PopulateItem(TObject item);

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            ObjectBinding<TObject> Object;
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.ByInternalId):
                    Object = ObjectBinding<TObject>.FromId(Id);
                    if(Overwrite)
                        // We need to reset if we're overwriting so we don't just erase fields
                        // if DisableLookupVerification is on
                        Object.Reset();
                    break;
                case nameof(ParameterSets.ByName):
                    Object = ObjectBinding<TObject>.FromName(Name);
                    // no need to reset here, FromName always fetches the full object
                    break;
                case nameof(ParameterSets.ByIdentity):
                    Object = Identity;
                    // We need to reset if we're overwriting so we don't just erase fields
                    // if DisableLookupVerification is on
                    Object.Reset();
                    break;
                default:
                    Object = GetBoundObject();
                    // we'll assume that there's no need to reset here.
                    if(null == Object)
                    {
                        this.WriteNotFoundError<TObject>("query", null);
                        return;
                    }
                    break;
            }

            // any errors that occur during lookup will be written to the error stream, and GetSingleValue will return false
            if(!this.GetSingleValue(Object, out var value))
                return;

            if(!PopulateItem(value))
                return;

            //TODO: error handling
            var response = Overwrite ? ApiHelper.Instance.GetEndPoint<TObject>().Set(value) // write all fields
                                     : ApiHelper.Instance.GetEndPoint<TObject>().Update(value); // write only modified fields
            if(PassThru)
                WriteObject(response);
        }

        /// <summary>
        /// Get the object binding to process if no default parameter set matches.
        /// </summary>
        protected virtual TBinding GetBoundObject()
            => null;
    }
}
