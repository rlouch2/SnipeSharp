using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
{
    [Cmdlet(VerbsCommon.Get, "AssignedAsset", DefaultParameterSetName = nameof(ParameterSets.ByUser))]
    public sealed class GetAssignedAsset: PSCmdlet
    {
        internal enum ParameterSets
        {
            ByUser,
            ByLocation,
            ByAsset
        }

        /// <summary>
        /// <para type="description">The user to find the assets of.</para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByUser))]
        public UserBinding[] User { get; set; }

        /// <summary>
        /// <para type="description">Indicates that incoming pipeline objects are users.</para>
        /// </summary>
        [Parameter(ParameterSetName = nameof(ParameterSets.ByUser))]
        public SwitchParameter Users { get; set; }

        /*
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByAsset))]
        public AssetBinding[] Asset { get; set; }

        [Parameter(ParameterSetName = nameof(ParameterSets.ByAsset))]
        public SwitchParameter Assets { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByLocation))]
        public ObjectBinding<Location>[] Location { get; set; }
        
        [Parameter(ParameterSetName = nameof(ParameterSets.ByLocation))]
        public SwitchParameter Locations { get; set; }
        */

        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == nameof(ParameterSets.ByUser))
            {
                foreach(var item in User)
                {
                    if(item.IsNull)
                    {
                        WriteError(new ErrorRecord(item.Error, $"User not found by identity \"{item.Query}\"", ErrorCategory.InvalidArgument, item.Query));
                    } else
                    {
                        WriteObject(ApiHelper.Instance.Users.GetAssignedAssets(item.Object), !NoEnumerate.IsPresent);
                    }
                }
            }
            /*
            else if(ParameterSetName == nameof(ParameterSets.ByLocation))
            {
                foreach(var item in Location)
                {
                    if(item.IsNull)
                    {
                        WriteError(new ErrorRecord(item.Error, $"Location not found by identity \"{item.Query}\"", ErrorCategory.InvalidArgument, item.Query));
                    } else
                    {
                        //WriteObject(ApiHelper.Instance.Locations.GetAssignedAssets(item.Object), !NoEnumerate.IsPresent);
                        throw new NotImplementedException();
                    }
                }
            } else
            {
                foreach(var item in Asset)
                {
                    if(item.IsNull)
                    {
                        WriteError(new ErrorRecord(item.Error, $"Asset not found by identity \"{item.Query}\"", ErrorCategory.InvalidArgument, item.Query));
                    } else
                    {
                        //WriteObject(ApiHelper.Instance.Assets.GetAssignedAssets(item.Object), !NoEnumerate.IsPresent);
                        throw new NotImplementedException();
                    }
                }
            }
            */
        }
    }
}