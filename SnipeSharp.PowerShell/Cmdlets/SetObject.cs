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
        where TObject: CommonEndPointModel, IUpdatable<TObject>, new()
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
        // This isn't PassThru because the object is not equivalent -- we would need to Get it again for that.
        [Parameter]
        public SwitchParameter ShowResponse { get; set; }

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
                    break;
                case nameof(ParameterSets.ByName):
                    Object = ObjectBinding<TObject>.FromName(Name);
                    break;
                case nameof(ParameterSets.ByIdentity):
                    Object = Identity;
                    break;
                default:
                    Object = GetBoundObject();
                    if(null == Object)
                    {
                        this.WriteNotFoundError<TObject>("query", null);
                        return;
                    }
                    break;
            }
            if(!this.GetSingleValue(Object, out var value))
                return;

            value = value.CloneForUpdate();
            if(!PopulateItem(value))
                return;

            //TODO: error handling
            var response = ApiHelper.Instance.GetEndPoint<TObject>().Update(value);
            if(ShowResponse)
                WriteObject(response);
        }

        /// <summary>
        /// Get the object binding to process if no default parameter set matches.
        /// </summary>
        protected virtual TBinding GetBoundObject()
            => null;
    }
}
