using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets
{
    /// <summary>
    /// Generic base class for Find* Cmdlets.
    /// </summary>
    /// <typeparam name="T">Type of object to find.</typeparam>
    /// <typeparam name="S">Sort column type.</typeparam>
    /// <typeparam name="K">Search filter type.</typeparam>
    public abstract class FindObject<T, S, K>: PSCmdlet
        where T: CommonEndPointModel
        where K: ISortableSearchFilter<S>, new()
    {
        /// <summary>
        /// <para type="description">The string to search for.</para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public string SearchString { get; set; }

        /// <summary>
        /// <para type="description">Which way to sort the data.</para>
        /// </summary>
        [Parameter]
        public SearchOrder SortOrder { get; set; }

        /// <summary>
        /// <para type="description">On which column to sort the data.</para>
        /// </summary>
        [Parameter]
        public S SortColumn { get; set; }

        /// <summary>
        /// <para type="description">If present, return the result as a <see cref="SnipeSharp.EndPoint.Models.ResponseCollection{T}"/> rather than enumerating.</para>
        /// </summary>
        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <summary>
        /// Populate the remaining fields of the filter.
        /// </summary>
        /// <param name="filter">The filter to populate.</param>
        protected abstract void PopulateFilter(ref K filter);

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var filter = new K();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SearchString)))
                filter.Search = SearchString;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                filter.Order = SortOrder;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.First)))
                filter.Limit = (int) PagingParameters.First;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.Skip)))
                filter.Offset = (int) PagingParameters.Skip;
            PopulateFilter(ref filter);
            try {
                var results = ApiHelper.Instance.GetEndPoint<T>().FindAll(filter);
                if(PagingParameters.IncludeTotalCount)
                    WriteObject(results.Total);
                WriteObject(results, !NoEnumerate);
            } catch(Exception e)
            {
                //TODO: improve error category
                WriteError(new ErrorRecord(e, e.Message, ErrorCategory.ReadError, null));
            }
        }
    }
}