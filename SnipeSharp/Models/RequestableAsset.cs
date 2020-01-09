using System;
using System.Collections.Generic;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// An asset that can be requested.
    /// </summary>
    public sealed class RequestableAsset : ApiObject, IAvailableActions
    {
        /// <summary>The ID of the asset.</summary>
        [Field(DeserializeAs = "id")]
        public int Id { get; private set; }

        /// <summary>The name of the asset.</summary>
        [Field(DeserializeAs = "name")]
        public string Name { get; private set; }

        /// <summary>The asset tag.</summary>
        [Field(DeserializeAs = "asset_tag")]
        public string AssetTag { get; private set; }

        /// <summary>The serial number.</summary>
        [Field(DeserializeAs = "serial")]
        public string Serial { get; private set; }

        /// <summary>The url for the image of the asset.</summary>
        [Field(DeserializeAs = "image")]
        public Uri ImageUri { get; private set; }

        /// <summary>The name of the model of the Asset.</summary>
        [Field(DeserializeAs = "model")]
        public string ModelName { get; private set; }

        /// <summary>The model number of the model of the Asset.</summary>
        [Field(DeserializeAs = "model_number")]
        public string ModelNumber { get; private set; }

        /// <summary>The name of the location the asset is at.</summary>
        [Field(DeserializeAs = "location")]
        public string LocationName { get; private set; }

        /// <summary>The deployment status of the asset.</summary>
        [Field(DeserializeAs = "status")]
        public StatusMeta StatusMeta { get; private set; }

        /// <summary>The date to the Asset is expected to be checked back in.</summary>
        [Field(DeserializeAs = "expected_checkin", Converter = FieldConverter.DateTimeConverter)]
        public DateTime? ExpectedCheckIn { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = FieldConverter.AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }
    }
}
