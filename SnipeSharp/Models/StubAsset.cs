using Newtonsoft.Json;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A stub asset, without the full properties of a normal asset.
    /// </summary>
    public sealed class StubAsset : Stub<Asset>
    {
        /// <summary>The asset tag of the asset.</summary>
        [DeserializeAs("asset_tag")]
        public string AssetTag { get; private set; }

        [JsonConstructor]
        private StubAsset() { }

        internal StubAsset(int id, string name, string assetTag)
            : base(id, name)
        {
            AssetTag = assetTag;
        }

        /// <summary>
        /// Transform a stub to a full asset, if for some reason you need to do that.
        /// </summary>
        public static implicit operator Asset(StubAsset stub) => new Asset
        {
            Id = stub.Id,
            Name = stub.Name,
            AssetTag = stub.AssetTag
        };

        /// <summary>
        /// Transform a full asset to a stub, for setting values.
        /// </summary>
        public static implicit operator StubAsset(Asset full) => new StubAsset
        {
            Id = full.Id,
            Name = full.Name,
            AssetTag = full.AssetTag
        };
    }
}
