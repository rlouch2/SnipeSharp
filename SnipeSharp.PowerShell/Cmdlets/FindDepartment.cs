using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.PowerShell.Enums;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, "Department",
        SupportsPaging = true
    )]
    [OutputType(typeof(Department))]
    public class FindDepartment: PSCmdlet
    {
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public string SearchString { get; set; }

        [Parameter]
        public Order SortOrder { get; set; }

        [Parameter]
        public SortColumn SortColumn { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var filter = new SearchFilter();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SearchString)))
                filter.Search = SearchString;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                filter.Order = SortOrder.ToApiString();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortColumn)))
                filter.Sort = SortColumn.ToApiString();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.First)))
                filter.Limit = (int) PagingParameters.First;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.Skip)))
                filter.Offset = (int) PagingParameters.Skip;
            var results = ApiHelper.Instance.DepartmentManager.FindAll(filter);
            // TODO: error handling
            if(PagingParameters.IncludeTotalCount)
                WriteObject(results.Total);
            WriteObject(results.Rows, true);
        }
    }
}