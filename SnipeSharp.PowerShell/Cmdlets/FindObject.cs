using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// Generic base class for Find* Cmdlets.
    /// </summary>
    /// <typeparam name="T">Type of object to find.</typeparam>
    /// <typeparam name="S">Sort column type.</typeparam>
    /// <typeparam name="K">Search filter type.</typeparam>
    public abstract class FindObject<T, S, K>: PSCmdlet
        where T: CommonEndPointModel
        where K: class, ISortableSearchFilter<S>, new()
    {
        /// <summary>The string to search for.</summary>
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public string SearchString { get; set; }

        /// <summary>Which way to sort the data.</summary>
        [Parameter]
        public SearchOrder SortOrder { get; set; }

        /// <summary>On which column to sort the data.</summary>
        [Parameter]
        public S SortColumn { get; set; }

        /// <summary>If present, return the result as a <see cref="SnipeSharp.Models.ResponseCollection{T}"/> rather than enumerating.</summary>
        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <summary>
        /// Populate the remaining fields of the filter.
        /// </summary>
        /// <param name="filter">The filter to populate.</param>
        protected abstract void PopulateFilter(K filter);

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
            PopulateFilter(filter);
            try {
                var results = ApiHelper.Instance.GetEndPoint<T>().FindAll(filter);
                if(PagingParameters.IncludeTotalCount)
                    WriteObject(results.Total);
                WriteObject(results, !NoEnumerate.IsPresent);
            } catch(Exception e)
            {
                WriteError(new ErrorRecord(e, e.Message, ErrorCategory.NotSpecified, null));
            }
        }
    }
}
