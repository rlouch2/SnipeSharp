using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.PowerShell.Enums;

namespace SnipeSharp.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "Asset",
        DefaultParameterSetName = "ByAssetTag"
    )]
    public class GetAsset: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ById",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public int Id { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByName",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByAssetTag",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string AssetTag { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "BySerial",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string Serial { get; set; }

        protected override void ProcessRecord()
        {
            var asset = default(Asset);
            switch(ParameterSetName)
            {
                case "ById":
                    asset = ApiHelper.Instance.AssetManager.Get(Id);
                    break;
                case "ByAssetTag":
                    asset = ApiHelper.Instance.AssetManager.GetByAssetTag(AssetTag);
                    break;
                case "ByName":
                    asset = ApiHelper.Instance.AssetManager.Get(Name);
                    break;
                case "BySerial":
                    asset = ApiHelper.Instance.AssetManager.GetBySerial(Serial);
                    break;
            }

            if(asset == null)
                throw new Exception("Asset not found");
            else
                WriteObject(asset);
        }
    }
}