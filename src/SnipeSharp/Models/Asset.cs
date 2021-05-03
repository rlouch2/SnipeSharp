using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.AssetConverter))]
    public sealed class Asset: IApiObject<Asset>
    {
        public int Id { get; }
        public string? Name { get; }
        public string AssetTag { get; }
        public string SerialNumber { get; }
        public Stub<Model>? Model { get; }
        public string? ModelNumber { get; }
        public FormattedDate? EndOfLife { get; }
        public AssetStatus Status { get; }
        public Stub<Category>? Category { get; }
        public Stub<Manufacturer>? Manufacturer { get; }
        public Stub<Supplier>? Supplier { get; }
        public string? Notes { get; }
        public string? OrderNumber { get; }
        public Stub<Company>? Company { get; }
        public Stub<Location>? Location { get; }
        public Stub<Location>? RtdLocation { get; }
        public Uri? Image { get; }
        // TODO: assigned_to
        public int? WarrantyMonths { get; }
        public FormattedDate? WarrantyExpires { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public FormattedDateTime? LastAudit { get; }
        public FormattedDate? NextAudit { get; }

        public bool IsDeleted => null != DeletedAt;
        public FormattedDateTime? DeletedAt { get; }
        public FormattedDate? PurchaseDate { get; }
        public FormattedDateTime? LastCheckout { get; }
        public FormattedDate? ExpectedCheckin { get; }
        public decimal? PurchaseCost { get; }
        public int CheckinCounter { get; }
        public int CheckoutCounter { get; }
        public int RequestsCounter { get; }
        public bool UserCanCheckout { get; }
        //TODO: custom fields

        public struct Actions
        {
            public bool Checkout { get; }
            public bool Checkin { get; }
            public bool Clone { get; }
            public bool Restore { get; }
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialAsset.Actions partial)
            {
                Checkout = partial.Checkout;
                Checkin = partial.Checkin;
                Clone = partial.Clone;
                Restore = partial.Restore;
                Update = partial.Update;
                Delete = partial.Delete;
            }
        }
        public readonly Actions AvailableActions;

        internal Asset(Serialization.PartialAsset partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name;
            AssetTag = partial.AssetTag ?? throw new ArgumentNullException(nameof(AssetTag));
            SerialNumber = partial.SerialNumber ?? throw new ArgumentNullException(nameof(SerialNumber));
            Model = partial.Model;
            ModelNumber = partial.ModelNumber;
            EndOfLife = partial.EndOfLife;
            Status = partial.Status ?? throw new ArgumentNullException(nameof(Status));
            Category = partial.Category;
            Manufacturer = partial.Manufacturer;
            Supplier = partial.Supplier;
            Notes = partial.Notes;
            OrderNumber = partial.OrderNumber;
            Company = partial.Company;
            Location = partial.Location;
            RtdLocation = partial.RtdLocation;
            Image = partial.Image;

            // warranty months is number + ' ' + "months" in the localized language.
            WarrantyMonths = null == partial.WarrantyMonths ? null : int.Parse(partial.WarrantyMonths.Split(' ')[0]);

            WarrantyExpires = partial.WarrantyExpires;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));

            LastAudit = partial.LastAudit;
            NextAudit = partial.NextAudit;
            DeletedAt = partial.DeletedAt;
            LastCheckout = partial.LastCheckout;
            ExpectedCheckin = partial.ExpectedCheckin;
            PurchaseCost = partial.PurchaseCost;
            CheckinCounter = partial.CheckinCounter;
            CheckoutCounter = partial.CheckoutCounter;
            RequestsCounter = partial.RequestsCounter;
            UserCanCheckout = partial.UserCanCheckout;
            //TODO
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    namespace Serialization
    {
        internal sealed class AssetConverter : JsonConverter<Asset>
        {
            public override Asset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialAsset>(ref reader, options);
                if(null == partial)
                    return null;
                return new Asset(partial);
            }

            public override void Write(Utf8JsonWriter writer, Asset value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialAsset
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.ASSET_TAG)]
            public string? AssetTag { get; set; }

            [JsonPropertyName(Static.SERIAL)]
            public string? SerialNumber { get; set; }

            [JsonPropertyName(Static.Types.MODEL)]
            public Stub<Model>? Model { get; set; }

            [JsonPropertyName(Static.MODEL_NUMBER)]
            public string? ModelNumber { get; set; }

            [JsonPropertyName(Static.Asset.END_OF_LIFE)]
            public FormattedDate? EndOfLife { get; set; }

            [JsonPropertyName(Static.STATUS)]
            public AssetStatus? Status { get; set; }

            [JsonPropertyName(Static.Types.CATEGORY)]
            public Stub<Category>? Category { get; set; }

            [JsonPropertyName(Static.Types.MANUFACTURER)]
            public Stub<Manufacturer>? Manufacturer { get; set; }

            [JsonPropertyName(Static.Types.SUPPLIER)]
            public Stub<Supplier>? Supplier { get; set; }

            [JsonPropertyName(Static.NOTES)]
            public string? Notes { get; set; }

            [JsonPropertyName(Static.Asset.ORDER_NUMBER)]
            public string? OrderNumber { get; set; }

            [JsonPropertyName(Static.Types.COMPANY)]
            public Stub<Company>? Company { get; set; }

            [JsonPropertyName(Static.Types.LOCATION)]
            public Stub<Location>? Location { get; set; }

            [JsonPropertyName(Static.Asset.RTD_LOCATION)]
            public Stub<Location>? RtdLocation { get; set; }

            [JsonPropertyName(Static.IMAGE)]
            public Uri? Image { get; set; }
            // TODO: assigned_to

            [JsonPropertyName(Static.Asset.WARRANTY_MONTHS)]
            public string? WarrantyMonths { get; set; }

            [JsonPropertyName(Static.Asset.WARRANTY_EXPIRES)]
            public FormattedDate? WarrantyExpires { get; set; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName(Static.Asset.LAST_AUDIT)]
            public FormattedDateTime? LastAudit { get; }

            [JsonPropertyName(Static.Asset.NEXT_AUDIT)]
            public FormattedDate? NextAudit { get; set; }

            [JsonPropertyName(Static.DELETED_AT)]
            public FormattedDateTime? DeletedAt { get; set; }

            [JsonPropertyName(Static.Asset.PURCHASE_DATE)]
            public FormattedDate? PurchaseDate { get; set; }

            [JsonPropertyName(Static.Asset.LAST_CHECKOUT)]
            public FormattedDateTime? LastCheckout { get; set; }

            [JsonPropertyName(Static.EXPECTED_CHECKIN)]
            public FormattedDate? ExpectedCheckin { get; set; }

            [JsonPropertyName(Static.Asset.PURCHASE_COST)]
            public decimal? PurchaseCost { get; set; }

            [JsonPropertyName(Static.Count.CHECKIN)]
            public int CheckinCounter { get; set; }

            [JsonPropertyName(Static.Count.CHECKOUT)]
            public int CheckoutCounter { get; set; }

            [JsonPropertyName(Static.Count.REQUESTS)]
            public int RequestsCounter { get; set; }

            [JsonPropertyName(Static.Asset.USER_CAN_CHECKOUT)]
            public bool UserCanCheckout { get; set; }
            //TODO: custom fields

            public struct Actions
            {
                [JsonPropertyName(Static.Actions.CHECKOUT)]
                public bool Checkout { get; set; }

                [JsonPropertyName(Static.Actions.CHECKIN)]
                public bool Checkin { get; set; }

                [JsonPropertyName(Static.Actions.CLONE)]
                public bool Clone { get; set; }

                [JsonPropertyName(Static.Actions.RESTORE)]
                public bool Restore { get; set; }

                [JsonPropertyName(Static.Actions.UPDATE)]
                public bool Update { get; set; }

                [JsonPropertyName(Static.Actions.DELETE)]
                public bool Delete { get; set; }
            }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }
        }
    }
}
