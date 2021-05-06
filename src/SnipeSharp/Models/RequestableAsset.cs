using System;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(RequestableAssetConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class RequestableAsset: IApiObject<RequestableAsset>, IApiObject<Asset>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.ASSET_TAG)]
        public string AssetTag { get; }

        [DeserializeAs(Static.SERIAL)]
        public string SerialNumber { get; }

        [DeserializeAs(Static.IMAGE)]
        public Uri? Image { get; }

        [DeserializeAs(Static.Types.MODEL)]
        public string? ModelName { get; }

        [DeserializeAs(Static.MODEL_NUMBER)]
        public string? ModelNumber { get; }

        [DeserializeAs(Static.EXPECTED_CHECKIN)]
        public FormattedDate ExpectedCheckIn { get; }

        [DeserializeAs(Static.Types.LOCATION)]
        public string? LocationName { get; }

        [DeserializeAs(Static.STATUS)]
        public StatusMeta Status { get; }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialRequestableAsset.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Cancel { get; }
            public bool Request { get; }
        }

        internal RequestableAsset(PartialRequestableAsset partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            AssetTag = partial.AssetTag ?? throw new ArgumentNullException(nameof(AssetTag));
            SerialNumber = partial.SerialNumber ?? throw new ArgumentNullException(nameof(SerialNumber));
            Image = partial.Image;
            ModelName = partial.ModelName;
            ModelNumber = partial.ModelNumber;
            ExpectedCheckIn = partial.ExpectedCheckIn ?? throw new ArgumentNullException(nameof(ExpectedCheckIn));
            LocationName = partial.LocationName;
            Status = partial.Status ?? throw new ArgumentNullException(nameof(Status));
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }
}
