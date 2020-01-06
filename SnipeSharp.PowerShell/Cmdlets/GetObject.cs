using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using System.Linq;
using SnipeSharp.Filters;
using System;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// Base class for most Get* Cmdlets, as they are fairly identical.
    /// </summary>
    /// <typeparam name="TObject">The type of object this cmdlet gets.</typeparam>
    /// <typeparam name="TBinding">The type of the Identity property.</typeparam>
    /// <typeparam name="TFilter">The type of the filter to use for lookup.</typeparam>
    public abstract class GetObject<TObject, TBinding, TFilter>: PSCmdlet
        where TObject: CommonEndPointModel, new()
        where TBinding: ObjectBinding<TObject>
        where TFilter: class, ISearchFilter, new()
    {
        /// <summary>
        /// Parameter sets supported by Get* cmdlets.
        /// </summary>
        internal enum ParameterSets
        {
            ByIdentity,
            ByInternalId,
            ByName,
            All
        }

        /// <summary>The internal Id of the Object.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByInternalId),
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public int[] InternalId { get; set; }

        /// <summary>The name of the Object.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByName),
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
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

        /// <summary>If present, return the result as a <see cref="SnipeSharp.Models.ResponseCollection{T}"/> rather than enumerating.</summary>
        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == nameof(ParameterSets.All))
            {
                var response = ApiHelper.Instance.GetEndPoint<TObject>().GetAllOptional();
                if(null != response.Exception)
                {
                    WriteError(new ErrorRecord(response.Exception, $"An error occurred retrieving all records from endpoint {typeof(TObject).Name}", ErrorCategory.NotSpecified, null));
                } else
                {
                    WriteObject(response.Value, !NoEnumerate.IsPresent);
                }
            } else
            {
                TFilter filter = new TFilter();
                if(!PopulateFilter(filter))
                    return;

                IEnumerable<TObject> objects;
                switch(ParameterSetName)
                {
                    case nameof(ParameterSets.ByName):
                        objects = GetByName(filter);
                        break;
                    case nameof(ParameterSets.ByInternalId):
                        objects = GetById();
                        break;
                    case nameof(ParameterSets.ByIdentity):
                        objects = GetByBinding((IEnumerable<TBinding>) Identity, filter);
                        break;
                    default:
                        objects = GetByBinding(GetBoundObjects(filter), filter);
                        break;
                }

                WriteObject(objects, !NoEnumerate.IsPresent);
            }
        }

        /// <summary>
        /// Retrieve items by name.
        /// </summary>
        /// <param name="filter">The search filter.</param>
        protected virtual IEnumerable<TObject> GetByName(TFilter filter)
        {
            foreach(var name in Name)
            {
                filter.Search = name;
                var item = ApiHelper.Instance.GetEndPoint<TObject>().FindAll(filter).Where(i => StringComparer.OrdinalIgnoreCase.Compare(i.Name, name) == 0).First();
                if(null == item)
                {
                    this.WriteNotFoundError<TObject>("name", name);
                    continue;
                }
                yield return item;
            }
        }

        /// <summary>
        /// Retrieve items from a binding enumerable.
        /// </summary>
        /// <param name="bindings">The bindings.</param>
        /// <param name="filter">The filter.</param>
        protected virtual IEnumerable<TObject> GetByBinding(IEnumerable<TBinding> bindings, TFilter filter)
        {
            foreach(var item in bindings)
            {
                item.Resolve(filter);
                if(!item.HasValue)
                {
                    this.WriteNotFoundError<TObject>("identity", item.Query, item.Error);
                    continue;
                }
                foreach(var value in item.Value)
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Retrieve items by internal ID.
        /// </summary>
        protected virtual IEnumerable<TObject> GetById()
        {
            foreach(var id in InternalId)
            {
                var response = ApiHelper.Instance.GetEndPoint<TObject>().GetOptional(id);
                if(!response.HasValue)
                {
                    this.WriteNotFoundError<TObject>("internal id", id.ToString(), response.Exception);
                    continue;
                }
                yield return response.Value;
            }
        }

        /// <summary>
        /// Get the list of object bindings to process if no default parameter set matches.
        /// </summary>
        /// <param name="filter">The search filter.</param>
        protected virtual IEnumerable<TBinding> GetBoundObjects(TFilter filter)
            => Enumerable.Empty<TBinding>();

        /// <summary>
        /// Populate the filter with any remaining or custom properties.
        /// </summary>
        /// <param name="filter">The filter to populate.</param>
        /// <returns>True if the operation should proceed.</returns>
        protected abstract bool PopulateFilter(TFilter filter);
    }

    /// <summary>
    /// Base class for most Get* Cmdlets, as they are fairly identical.
    /// </summary>
    /// <typeparam name="TObject">The type of object this cmdlet gets.</typeparam>
    /// <typeparam name="TBinding">The type of the Identity property.</typeparam>
    public abstract class GetObject<TObject, TBinding>: GetObject<TObject, TBinding, SearchFilter>
        where TObject: CommonEndPointModel, new()
        where TBinding: ObjectBinding<TObject>
    {
        /// <inheritdoc />
        protected override bool PopulateFilter(SearchFilter filter)
        {
            return true;
        }

        /// <inheritdoc />
        protected override IEnumerable<TBinding> GetBoundObjects(SearchFilter filter)
            => GetBoundObjects();

        /// <summary>
        /// Get the list of object bindings to process if no default parameter set matches.
        /// </summary>
        protected virtual IEnumerable<TBinding> GetBoundObjects()
            => Enumerable.Empty<TBinding>();
    }
}
