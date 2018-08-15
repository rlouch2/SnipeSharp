using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets
{
    /// <summary>
    /// Generic base class for Set* Cmdlets.
    /// </summary>
    /// <typeparam name="T">Type of object to set.</typeparam>
    public abstract class SetObject<T>: PSCmdlet where T: CommonEndPointModel
    {
        internal enum ParameterSets
        {
            ByIdentity,
            ByName,
            ByInternalId
        }

        /// <summary>
        /// <para type="description">The identity of the item to update.</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByIdentity))]
        [ValidateIdentityNotNull]
        public ObjectBinding<T> Identity { get; set; }

        /// <summary>
        /// <para type="description">The name of the item to update.</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(ParameterSets.ByName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">The id of the item to update.</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(ParameterSets.ByInternalId))]
        public int Id { get; set; }

        /// <summary>
        /// Populate the fields of the item.
        /// </summary>
        /// <param name="item">The item to populate.</param>
        protected abstract void PopulateItem(T item);

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.ByInternalId):
                    Identity = ObjectBinding<T>.FromId(Id);
                    break;
                case nameof(ParameterSets.ByName):
                    Identity = ObjectBinding<T>.FromName(Name);
                    break;
                case nameof(ParameterSets.ByIdentity):
                    break;
            }
            if(Identity.IsNull)
            {
                WriteError(new ErrorRecord(Identity.Error, $"{typeof(T).Name} not found: {Identity.Query}", ErrorCategory.InvalidArgument, null));
                return;
            }
            PopulateItem(Identity.Object);

            //TODO: error handling
            WriteObject(ApiHelper.Instance.GetEndPoint<T>().Update(Identity.Object));
        }
    }
}