using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using System;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds requestable Snipe IT assets.</summary>
    /// <remarks>The Find-RequestableAsset cmdlet finds requestable asset objects by filter.</remarks>
    /// <example>
    ///   <code>Find-RequestableAsset</code>
    ///   <para>Finds all requestable assets.</para>
    /// </example>
    /// <example>
    ///   <code>Find-RequestableAsset "PotatoPeeler"</code>
    ///   <para>Finds requestable assets that match the search string "PotatoPeeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(RequestableAsset), SupportsPaging = true)]
    [OutputType(typeof(RequestableAsset))]
    public class FindRequestableAsset: PSCmdlet
    {
        /// <summary>The string to search for.</summary>
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public string SearchString { get; set; }

        /// <summary>Which way to sort the data.</summary>
        [Parameter]
        public SearchOrder SortOrder { get; set; }

        /// <summary>On which column to sort the data.</summary>
        [Parameter]
        public RequestableAssetSearchColumn? SortColumn { get; set; } = null;

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var filter = new RequestableAssetSearchFilter();
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
                var results = ApiHelper.Instance.Account.GetRequestableAssets(filter);
                if(PagingParameters.IncludeTotalCount)
                    WriteObject(results.Total);
                WriteObject(results, true);
            } catch(Exception e)
            {
                WriteError(new ErrorRecord(e, e.Message, ErrorCategory.NotSpecified, null));
            }
        }
    }
}
