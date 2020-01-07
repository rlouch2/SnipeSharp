using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT asset.</summary>
    /// <remarks>
    ///   <para>The Get-Asset cmdlet gets one or more asset objects.</para>
    ///   <para>The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.</para>
    /// </remarks>
    /// <example>
    ///   <code>Get-Asset Asset4638</code>
    ///   <para>Retrieve an asset by its Identity.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Asset -Name Asset4368</code>
    ///   <para>Retrieve an asset explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Asset</code>
    ///   <para>Retrieve the first 100 assets by their identities.</para>
    /// </example>
    /// <seealso cref="FindAsset" />
    [Cmdlet(VerbsCommon.Get, nameof(Asset), DefaultParameterSetName = nameof(GetAsset.ParameterSets.All))]
    [OutputType(typeof(Asset))]
    public sealed class GetAsset: GetObject<Asset, AssetBinding>
    {
        /// <summary>
        /// Extra parameter sets this cmdlet supports.
        /// </summary>
        internal enum AssetParameterSets
        {
            ByAssetTag,
            BySerial
        }

        /// <summary>The asset tag for the Asset.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(AssetParameterSets.ByAssetTag)
        )]
        public string[] AssetTag { get; set; }

        /// <summary>The serial Id for the Asset.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(AssetParameterSets.BySerial)
        )]
        public string[] Serial { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            IEnumerable<Asset> objects;
            if(ParameterSetName == nameof(ParameterSets.All))
            {
                var response = ApiHelper.Instance.Assets.GetAllOptional();
                if(null != response.Exception)
                {
                    WriteError(new ErrorRecord(response.Exception, $"An error occurred retrieving all records from endpoint {nameof(Asset)}", ErrorCategory.NotSpecified, null));
                    return;
                } else
                {
                    objects = response.Value;
                }
            } else
            {
                var filter = new SearchFilter();
                if(!PopulateFilter(filter))
                    return;

                switch(ParameterSetName)
                {
                    case nameof(ParameterSets.ByName):
                        objects = GetByName(filter);
                        break;
                    case nameof(ParameterSets.ByInternalId):
                        objects = GetById();
                        break;
                    case nameof(ParameterSets.ByIdentity):
                        objects = GetByBinding((IEnumerable<AssetBinding>) Identity, filter);
                        break;
                    default:
                        objects = GetByBinding(GetBoundObjects(filter), filter);
                        break;
                }
            }
            foreach(var asset in objects)
            {
                var assetObj = PSObject.AsPSObject(asset);
                foreach(var pair in asset.CustomFields.Friendly)
                    assetObj.Properties.Add(new PSAssetCustomFieldProperty(pair.Key, pair.Key));
                WriteObject(assetObj);
            }
        }

        /// <inheritdoc />
        protected override IEnumerable<AssetBinding> GetBoundObjects(SearchFilter filter)
        {
            if(ParameterSetName == nameof(AssetParameterSets.ByAssetTag))
            {
                foreach(var item in AssetTag)
                    yield return AssetBinding.FromTag(item);
            } else
            {
                foreach(var item in Serial)
                    yield return AssetBinding.FromSerial(item);
            }
        }
    }
}
