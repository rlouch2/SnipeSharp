using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// Generic base class for Find* Cmdlets with a special column type.
    /// </summary>
    /// <typeparam name="TObject">Type of object to find.</typeparam>
    /// <typeparam name="TColumn">Sort column type.</typeparam>
    /// <typeparam name="TFilter">Search filter type.</typeparam>
    public abstract class FindObject<TObject, TColumn, TFilter>: PSCmdlet
        where TObject: CommonEndPointModel
        where TFilter: class, ISortableSearchFilter<TColumn?>, new()
        where TColumn: struct, Enum
    {
        /// <summary>The string to search for.</summary>
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public string SearchString { get; set; }

        /// <summary>Which way to sort the data.</summary>
        [Parameter]
        public SearchOrder SortOrder { get; set; }

        /// <summary>On which column to sort the data.</summary>
        [Parameter]
        public TColumn? SortColumn { get; set; } = null;

        /// <summary>
        /// Populate the remaining fields of the filter.
        /// </summary>
        /// <param name="filter">The filter to populate.</param>
        /// <returns>True if the operation should proceed.</returns>
        protected abstract bool PopulateFilter(TFilter filter);

        /// <summary>
        /// Emit the results of the query to the pipeline.
        /// </summary>
        protected virtual void EmitResults(ResponseCollection<TObject> collection)
            => WriteObject(collection, true);

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var filter = new TFilter();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SearchString)))
                filter.Search = SearchString;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                filter.Order = SortOrder;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortColumn)))
                filter.SortColumn = SortColumn;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.First)))
                filter.Limit = (int) PagingParameters.First;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.Skip)))
                filter.Offset = (int) PagingParameters.Skip;
            if(!PopulateFilter(filter))
                return;
            try {
                var results = ApiHelper.Instance.GetEndPoint<TObject>().FindAll(filter);
                if(PagingParameters.IncludeTotalCount)
                    WriteObject(results.Total);
                EmitResults(results);
            } catch(Exception e)
            {
                WriteError(new ErrorRecord(e, e.Message, ErrorCategory.NotSpecified, null));
            }
        }
    }

    /// <summary>
    /// Generic base class for Find* Cmdlets with no special column type or filter.
    /// </summary>
    /// <typeparam name="TObject">Type of object to find.</typeparam>
    public abstract class FindObject<TObject>: PSCmdlet
        where TObject: CommonEndPointModel
    {
        /// <summary>The string to search for.</summary>
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public string SearchString { get; set; }

        /// <summary>Which way to sort the data.</summary>
        [Parameter]
        public SearchOrder SortOrder { get; set; }

        /// <summary>On which column to sort the data.</summary>
        [Parameter]
        public string SortColumn { get; set; }

        /// <summary>
        /// Emit the results of the query to the pipeline.
        /// </summary>
        protected virtual void EmitResults(ResponseCollection<TObject> collection)
            => WriteObject(collection, true);

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var filter = new SearchFilter();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SearchString)))
                filter.Search = SearchString;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                filter.Order = SortOrder;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortColumn)))
                filter.SortColumn = SortColumn;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.First)))
                filter.Limit = (int) PagingParameters.First;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.Skip)))
                filter.Offset = (int) PagingParameters.Skip;
            try {
                var results = ApiHelper.Instance.GetEndPoint<TObject>().FindAll(filter);
                if(PagingParameters.IncludeTotalCount)
                    WriteObject(results.Total);
                EmitResults(results);
            } catch(Exception e)
            {
                WriteError(new ErrorRecord(e, e.Message, ErrorCategory.NotSpecified, null));
            }
        }
    }
}
