using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.PowerShell.Enums;

namespace SnipeSharp.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "Asset", SupportsPaging = true)]
    public class FindAsset: PSCmdlet
    {
        [Parameter()]
        public AssetSort SortBy { get; set; }

        [Parameter()]
        public Order Order { get; set; }

        [Parameter(Position = 0)]
        public string SearchString { get; set; }

        [Parameter()]
        public Model Model { get; set; }

        [Parameter()]
        public Category Category { get; set; }

        [Parameter()]
        public Manufacturer Manufacturer { get; set; }

        [Parameter()]
        public Company Company { get; set; }

        [Parameter()]
        public Location Location { get; set; }

        [Parameter()]
        public StatusLabel Status { get; set; }

        protected override void BeginProcessing()
        {
            // TODO: ???
        }

        protected override void ProcessRecord()
        {
            var filter = new AssetSearchFilter();

            if(MyInvocation.BoundParameters.ContainsKey("Company"))
                filter.CompanyId = (int) Company.Id;
        }

        protected override void EndProcessing()
        {
            // TODO: make it deal with all input?
        }
    }
}