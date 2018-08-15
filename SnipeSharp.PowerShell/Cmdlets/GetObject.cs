using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// Base class for most Get* Cmdlets, as they are fairly identical.
    /// </summary>
    /// <typeparam name="T">The type of object this cmdlet gets.</typeparam>
    public abstract class GetObject<T>: PSCmdlet where T: CommonEndPointModel
    {
        internal enum ParameterSets
        {
            ByIdentity,
            ByInternalId,
            ByName,
            All
        }

        /// <summary>
        /// <para type="description">The name of the Object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByInternalId),
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public int[] InternalId { get; set; }

        /// <summary>
        /// <para type="description">The internal Id of the Object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByName),
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string[] Name { get; set; }


        /// <summary>
        /// <para type="description">An identity for an object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByIdentity),
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public ObjectBinding<T>[] Identity { get; set; }

        /// <summary>
        /// <para type="description">If present, return the result as a <see cref="SnipeSharp.Models.ResponseCollection{T}"/> rather than enumerating.</para>
        /// </summary>
        [Parameter(ParameterSetName = nameof(ParameterSets.All))]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == nameof(ParameterSets.All))
            {
                var (item, error) = ApiHelper.Instance.GetEndPoint<T>().GetAllOrNull();
                if(!(error is null))
                {
                    WriteError(new ErrorRecord(error, $"An error occurred retrieving all records from endpoint {typeof(T).Name}", ErrorCategory.NotSpecified, null));
                } else
                {
                    WriteObject(item, !NoEnumerate.IsPresent);
                }
            } else if(ParameterSetName == nameof(ParameterSets.ByName))
            {
                foreach(var name in Name)
                {
                    var (item, error) = ApiHelper.Instance.GetEndPoint<T>().GetOrNull(name);
                    if(item is null)
                    {
                        WriteError(new ErrorRecord(error, $"{typeof(T).Name} not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            } else if(ParameterSetName == nameof(ParameterSets.ByInternalId))
            {
                foreach(var id in InternalId)
                {
                    var (item, error) = ApiHelper.Instance.GetEndPoint<T>().GetOrNull(id);
                    if(item is null)
                    {
                        WriteError(new ErrorRecord(error, $"{typeof(T).Name} not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            } else
            {
                foreach(var item in Identity)
                {
                    if(item.IsNull)
                    {
                        WriteError(new ErrorRecord(item.Error, $"{typeof(T).Name} not found by identity \"{item.Query}\"", ErrorCategory.InvalidArgument, item.Query));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            }
        }
    }
}
