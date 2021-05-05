using System;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(StubAssetConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed class StubAsset: IApiObject<Asset>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string? Name { get; }

        [DeserializeAs(Static.ASSET_TAG)]
        public string AssetTag { get; }

        internal StubAsset(PartialStubAsset partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name;
            AssetTag = partial.AssetTag ?? throw new ArgumentNullException(nameof(AssetTag));
        }

        public override string ToString() => Name ?? AssetTag;
    }
}
