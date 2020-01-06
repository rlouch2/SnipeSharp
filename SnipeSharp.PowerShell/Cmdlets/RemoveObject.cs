using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// Base class for most Remove* Cmdlets, as they are fairly identical.
    /// </summary>
    /// <typeparam name="TObject">The type of object this cmdlet gets.</typeparam>
    /// <typeparam name="TBinding">The type of the Identity property.</typeparam>
    public abstract class RemoveObject<TObject, TBinding>: PSCmdlet
        where TObject: CommonEndPointModel, new()
        where TBinding: ObjectBinding<TObject>
    {
        /// <summary>
        /// Parameter sets supported by Remove* cmdlets.
        /// </summary>
        internal enum ParameterSets
        {
            ByIdentity,
            ByInternalId,
            ByName
        }

        /// <summary>The name of the Object.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(ParameterSets.ByInternalId), ValueFromPipelineByPropertyName = true)]
        public int[] InternalId { get; set; }

        /// <summary>The internal Id of the Object.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(ParameterSets.ByName), ValueFromPipelineByPropertyName = true)]
        public string[] Name { get; set; }


        /// <summary>An identity for an object.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByIdentity),
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public TBinding[] Identity { get; set; }

        /// <summary>If present, write the response from the Api to the pipeline.</summary>
        [Parameter]
        public SwitchParameter ShowResponse { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var endPoint = ApiHelper.Instance.GetEndPoint<TObject>();
            if(ParameterSetName == nameof(ParameterSets.ByName))
            {
                foreach(var name in Name)
                {
                    var getResponse = endPoint.GetOptional(name);
                    if(null != getResponse.Exception)
                    {
                        WriteError(new ErrorRecord(getResponse.Exception, $"{typeof(TObject).Name} not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else if(ShouldProcess(name))
                    {
                        var deleteResponse = endPoint.Delete(getResponse.Value.Id);
                        if(ShowResponse.IsPresent)
                            WriteObject(deleteResponse);
                    }
                }
            } else if(ParameterSetName == nameof(ParameterSets.ByInternalId))
            {
                foreach(var id in InternalId)
                {
                    var getResponse = endPoint.GetOptional(id);
                    if(null != getResponse.Exception)
                    {
                        WriteError(new ErrorRecord(getResponse.Exception, $"{typeof(TObject).Name} not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(id.ToString()))
                    {
                        var deleteResponse = endPoint.Delete(getResponse.Value.Id);
                        if(ShowResponse.IsPresent)
                            WriteObject(deleteResponse);
                    }
                }
            } else if(ParameterSetName == nameof(ParameterSets.ByIdentity))
            {
                foreach(var item in Identity)
                {
                    if(!this.ValidateHasExactlyOneValue(item, queryType: "identity"))
                    {
                        return;
                    } else if(ShouldProcess(item.Value[0].Name))
                    {
                        var deleteResponse = endPoint.Delete(item.Value[0].Id);
                        if(ShowResponse.IsPresent)
                            WriteObject(deleteResponse);
                    }
                }
            } else
            {
                foreach(var item in GetBoundObjects())
                {
                    if(!this.ValidateHasExactlyOneValue(item, queryType: "identity"))
                    {
                        return;
                    } else if(ShouldProcess(item.Value[0].Name))
                    {
                        var deleteResponse = endPoint.Delete(item.Value[0].Id);
                        if(ShowResponse.IsPresent)
                            WriteObject(deleteResponse);
                    }
                }
            }
        }

        /// <summary>
        /// Get the list of object bindings to process if no default parameter set matches.
        /// </summary>
        protected virtual IEnumerable<TBinding> GetBoundObjects()
            => Enumerable.Empty<TBinding>();
    }
}
