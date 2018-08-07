using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.PowerShell.Enums;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, "Asset",
        SupportsPaging = true
    )]
    [OutputType(typeof(Asset))]
    public class FindAsset: PSCmdlet
    {
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public string SearchString { get; set; }

        [Parameter]
        public Order SortOrder { get; set; }

        [Parameter]
        public SortColumn SortColumn { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        [ValidateIdentityNotNull]
        public ModelIdentity Model { get; set; }
        
        [Parameter]
        [ValidateIdentityNotNull]
        public CategoryIdentity Category { get; set; }

        [Parameter]
        [ValidateIdentityNotNull]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        [ValidateIdentityNotNull]
        public LocationIdentity Location { get; set; }

        [Parameter]
        public string Status { get; set; }

        [Parameter]
        public StatusLabelIdentity StatusLabel { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var filter = new AssetSearchFilter();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SearchString)))
                filter.Search = SearchString;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                filter.Order = SortOrder.ToApiString();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortColumn)))
                filter.Sort = SortColumn.ToApiString();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                filter.OrderNumber = OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Model)))
                filter.ModelId = (int) Model.Model.Id;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                filter.CategoryId = (int) Category.Category.Id;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                filter.CompanyId = (int) Company.Company.Id;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                filter.Location = Location.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                filter.Status = Status;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(StatusLabel)))
                filter.StatusId = (int) StatusLabel.StatusLabel.Id;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.First)))
                filter.Limit = (int) PagingParameters.First;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.Skip)))
                filter.Offset = (int) PagingParameters.Skip;
            var results = ApiHelper.Instance.AssetManager.FindAll(filter);
            // TODO: error handling
            if(PagingParameters.IncludeTotalCount)
                WriteObject(results.Total);
            WriteObject(results.Rows, true);
        }
    }
}