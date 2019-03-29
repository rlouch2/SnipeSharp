using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets the Snipe IT assets assigned to a user.</summary>
    /// <remarks>The Get-AssignedAsset cmdlet gets, for each user provided, the asset objects associated with that user.</remarks>
    /// <example>
    ///   <code>Get-AssignedAsset User1234</code>
    ///   <para>Retrieves the assets assigned to the user User1234.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Asset User1234, User5678</code>
    ///   <para>Retrieve the assets assigned to the user User1234 or the user User5678.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Get, "AssignedAsset", DefaultParameterSetName = nameof(ParameterSets.ByUser))]
    [OutputType(typeof(Asset))]
    public sealed class GetAssignedAsset: BaseCmdlet
    {
        /// <summary>
        /// Parameter sets this cmdlet supports
        /// </summary>
        internal enum ParameterSets
        {
            ByUser,
            ByLocation,
            ByAsset
        }

        /// <summary>The user to find the assets of.</summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByUser))]
        public UserBinding[] User { get; set; }

        /*
        /// <summary>Indicates that incoming pipeline objects are users.</summary>
        [Parameter(ParameterSetName = nameof(ParameterSets.ByUser))]
        public SwitchParameter Users { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByAsset))]
        public AssetBinding[] Asset { get; set; }

        [Parameter(ParameterSetName = nameof(ParameterSets.ByAsset))]
        public SwitchParameter Assets { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByLocation))]
        public ObjectBinding<Location>[] Location { get; set; }

        [Parameter(ParameterSetName = nameof(ParameterSets.ByLocation))]
        public SwitchParameter Locations { get; set; }
        */

        /// <summary>If present, return the result as a <see cref="SnipeSharp.Models.ResponseCollection{T}"/> rather than enumerating.</summary>
        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == nameof(ParameterSets.ByUser))
            {
                foreach(var item in User)
                {
                    if (GetSingleValue(item, out var itemValue))
                        WriteObject(ApiHelper.Instance.Users.GetAssignedAssets(itemValue), !NoEnumerate.IsPresent);
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
