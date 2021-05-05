using System;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(AssetConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class Asset: IApiObject<Asset>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string? Name { get; }

        [DeserializeAs(Static.ASSET_TAG)]
        public string AssetTag { get; }

        [DeserializeAs(Static.SERIAL)]
        public string SerialNumber { get; }

        [DeserializeAs(Static.Types.MODEL)]
        public Stub<Model>? Model { get; }

        [DeserializeAs(Static.MODEL_NUMBER)]
        public string? ModelNumber { get; }

        [DeserializeAs(Static.Asset.END_OF_LIFE)]
        public FormattedDate? EndOfLife { get; }

        [DeserializeAs(Static.STATUS)]
        public AssetStatus Status { get; }

        [DeserializeAs(Static.Types.CATEGORY)]
        public Stub<Category>? Category { get; }

        [DeserializeAs(Static.Types.MANUFACTURER)]
        public Stub<Manufacturer>? Manufacturer { get; }

        [DeserializeAs(Static.Types.SUPPLIER)]
        public Stub<Supplier>? Supplier { get; }

        [DeserializeAs(Static.NOTES)]
        public string? Notes { get; }

        [DeserializeAs(Static.Asset.ORDER_NUMBER)]
        public string? OrderNumber { get; }

        [DeserializeAs(Static.Types.COMPANY)]
        public Stub<Company>? Company { get; }

        [DeserializeAs(Static.Types.LOCATION)]
        public Stub<Location>? Location { get; }

        [DeserializeAs(Static.Asset.RTD_LOCATION)]
        public Stub<Location>? RtdLocation { get; }

        [DeserializeAs(Static.IMAGE)]
        public Uri? Image { get; }
        // TODO: assigned_to

        [DeserializeAs(Static.Asset.WARRANTY_MONTHS, Type = typeof(string))]
        public int? WarrantyMonths { get; }

        [DeserializeAs(Static.Asset.WARRANTY_EXPIRES)]
        public FormattedDate? WarrantyExpires { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.Asset.LAST_AUDIT)]
        public FormattedDateTime? LastAudit { get; }

        [DeserializeAs(Static.Asset.NEXT_AUDIT)]
        public FormattedDate? NextAudit { get; }

        public bool IsDeleted => null != DeletedAt;

        [DeserializeAs(Static.DELETED_AT)]
        public FormattedDateTime? DeletedAt { get; }

        [DeserializeAs(Static.Asset.PURCHASE_DATE)]
        public FormattedDate? PurchaseDate { get; }

        [DeserializeAs(Static.Asset.LAST_CHECKOUT)]
        public FormattedDateTime? LastCheckout { get; }

        [DeserializeAs(Static.EXPECTED_CHECKIN)]
        public FormattedDate? ExpectedCheckin { get; }

        [DeserializeAs(Static.Asset.PURCHASE_COST)]
        public decimal? PurchaseCost { get; }

        [DeserializeAs(Static.Count.CHECKIN, IsNonNullable = true)]
        public int CheckinCounter { get; }

        [DeserializeAs(Static.Count.CHECKOUT, IsNonNullable = true)]
        public int CheckoutCounter { get; }

        [DeserializeAs(Static.Count.REQUESTS, IsNonNullable = true)]
        public int RequestsCounter { get; }

        [DeserializeAs(Static.Asset.USER_CAN_CHECKOUT, IsNonNullable = true)]
        public bool UserCanCheckout { get; }
        //TODO: custom fields

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Checkout { get; }
            public bool Checkin { get; }
            public bool Clone { get; }
            public bool Restore { get; }
            public bool Update { get; }
            public bool Delete { get; }
        }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialAsset.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        internal Asset(PartialAsset partial)
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
}
