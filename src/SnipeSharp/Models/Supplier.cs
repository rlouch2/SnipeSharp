using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(SupplierConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class Supplier : IApiObject<Supplier>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.IMAGE)]
        public Uri? Image { get; }

        [DeserializeAs(Static.URL)]
        public string Url { get; }

        [DeserializeAs(Static.Location.ADDRESS)]
        public string Address { get; }

        [DeserializeAs(Static.Location.ADDRESS2)]
        public string Address2 { get; }

        [DeserializeAs(Static.Location.CITY)]
        public string City { get; }

        [DeserializeAs(Static.Location.STATE)]
        public string State { get; }

        [DeserializeAs(Static.Location.COUNTRY)]
        public string Country { get; }

        [DeserializeAs(Static.Location.ZIP)]
        public string ZipCode { get; }

        [DeserializeAs(Static.Supplier.FAX)]
        public string FaxNumber { get; }

        [DeserializeAs(Static.User.PHONE)]
        public string PhoneNumber { get; }

        [DeserializeAs(Static.User.EMAIL)]
        public string EmailAddress { get; }

        [DeserializeAs(Static.Supplier.CONTACT)]
        public string Contact { get; }

        [DeserializeAs(Static.Count.ASSETS, IsNonNullable = true)]
        public int AssetsCount { get; }

        [DeserializeAs(Static.Count.ACCESSORIES, IsNonNullable = true)]
        public int AccessoriesCount { get; }

        [DeserializeAs(Static.Count.LICENSES, IsNonNullable = true)]
        public int LicensesCount { get; }

        [DeserializeAs(Static.NOTES)]
        public string? Notes { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialSupplier.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
        }

        internal Supplier(PartialSupplier partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            Image = partial.Image;
            Url = partial.Url ?? throw new ArgumentNullException(nameof(Url));
            Address = partial.Address ?? throw new ArgumentNullException(nameof(Address));
            Address2 = partial.Address2 ?? throw new ArgumentNullException(nameof(Address2));
            City = partial.City ?? throw new ArgumentNullException(nameof(City));
            State = partial.State ?? throw new ArgumentNullException(nameof(State));
            Country = partial.Country ?? throw new ArgumentNullException(nameof(Country));
            ZipCode = partial.ZipCode ?? throw new ArgumentNullException(nameof(ZipCode));
            FaxNumber = partial.FaxNumber ?? throw new ArgumentNullException(nameof(FaxNumber));
            PhoneNumber = partial.PhoneNumber ?? throw new ArgumentNullException(nameof(PhoneNumber));
            EmailAddress = partial.EmailAddress ?? throw new ArgumentNullException(nameof(EmailAddress));
            Contact = partial.Contact ?? throw new ArgumentNullException(nameof(Contact));
            AssetsCount = partial.AssetsCount;
            AccessoriesCount = partial.AccessoriesCount;
            LicensesCount = partial.LicensesCount;
            Notes = partial.Notes;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    [GenerateFilter(typeof(SupplierSortOn))]
    public sealed partial class SupplierFilter: IFilter<Supplier>
    {
    }

    [SortColumn]
    public enum SupplierSortOn
    {
        [EnumMember(Value = Static.CREATED_AT)]
        CreatedAt = 0,

        [EnumMember(Value = Static.Count.ACCESSORIES)]
        AccessoriesCount,

        [EnumMember(Value = Static.Location.ADDRESS)]
        Address,

        [EnumMember(Value = Static.Count.ASSETS)]
        AssetsCount,

        [EnumMember(Value = Static.Supplier.CONTACT)]
        Contact,

        [EnumMember(Value = Static.User.EMAIL)]
        EmailAddress,

        [EnumMember(Value = Static.Supplier.FAX)]
        FaxNumber,

        [EnumMember(Value = Static.ID)]
        Id,

        [EnumMember(Value = Static.IMAGE)]
        Image,

        [EnumMember(Value = Static.Count.LICENSES)]
        LicensesCount,

        [EnumMember(Value = Static.NAME)]
        Name,

        [EnumMember(Value = Static.User.PHONE)]
        PhoneNumber,

        [EnumMember(Value = Static.URL)]
        Url,
    }
}
