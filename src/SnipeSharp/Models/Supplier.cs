using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.SupplierConverter))]
    public sealed class Supplier : IApiObject<Supplier>
    {
        public int Id { get; }
        public string Name { get; }
        public Uri? Image { get; }
        public string Url { get; }
        public string Address { get; }
        public string Address2 { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public string FaxNumber { get; }
        public string PhoneNumber { get; }
        public string EmailAddress { get; }
        public string Contact { get; }
        public int AssetsCount { get; }
        public int AccessoriesCount { get; }
        public int LicensesCount { get; }
        public string? Notes { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }

        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialSupplier.Actions partial)
                => (Update, Delete) = partial;
        }

        internal Supplier(Serialization.PartialSupplier partial)
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

    public sealed class SupplierFilter: IFilter<Supplier>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }
        public SortOrder? SortOrder { get; set; }
        public SupplierSortOn? SortOn { get; set; }

        IFilter<Supplier> IFilter<Supplier>.Clone()
            => new SupplierFilter
            {
                Limit = Limit,
                Offset = Offset,
                SearchString = SearchString,
                SortOrder = SortOrder,
                SortOn = SortOn
            };

        IReadOnlyDictionary<string, string?> IFilter<Supplier>.GetParameters()
        {
            var dict = new Dictionary<string, string?>();
            if(null != Limit)
                dict["limit"] = Limit.ToString();
            if(null != Offset)
                dict["offset"] = Offset.ToString();
            if(null != SearchString)
                dict["search"] = SearchString;
            var order = SortOrder.Serialize();
            if(null != order)
                dict["order"] = order;
            var column = SortOn.Serialize();
            if(null != column)
                dict["sort"] = column;
            return dict;
        }
    }

    public enum SupplierSortOn
    {
        CreatedAt = 0,
        AccessoriesCount,
        Address,
        AssetsCount,
        Contact,
        EmailAddress,
        FaxNumber,
        Id,
        Image,
        LicensesCount,
        Name,
        PhoneNumber,
        Url,
    }

    public static class SupplierSortOnExtensions
    {
        public static string? Serialize(this SupplierSortOn? self)
            => self switch
            {
                SupplierSortOn.CreatedAt => "created_at",
                SupplierSortOn.AccessoriesCount => "accessories_count",
                SupplierSortOn.Address => "address",
                SupplierSortOn.AssetsCount => "assets_count",
                SupplierSortOn.Contact => "contact",
                SupplierSortOn.EmailAddress => "email",
                SupplierSortOn.FaxNumber => "fax",
                SupplierSortOn.Id => "id",
                SupplierSortOn.Image => "image",
                SupplierSortOn.LicensesCount => "licenses_count",
                SupplierSortOn.Name => "name",
                SupplierSortOn.PhoneNumber => "phone",
                SupplierSortOn.Url => "url",
                _ => null
            };
    }

    namespace Serialization
    {
        internal sealed class SupplierConverter : JsonConverter<Supplier>
        {
            public override Supplier? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialSupplier>(ref reader, options);
                if(null == partial)
                    return null;
                return new Supplier(partial);
            }

            public override void Write(Utf8JsonWriter writer, Supplier value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialSupplier
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("image")]
            public Uri? Image { get; set; }

            [JsonPropertyName("url")]
            public string? Url { get; set; }

            [JsonPropertyName("address")]
            public string? Address { get; set; }

            [JsonPropertyName("address2")]
            public string? Address2 { get; set; }

            [JsonPropertyName("city")]
            public string? City { get; set; }

            [JsonPropertyName("state")]
            public string? State { get; set; }

            [JsonPropertyName("country")]
            public string? Country { get; set; }

            [JsonPropertyName("zip")]
            public string? ZipCode { get; set; }

            [JsonPropertyName("fax")]
            public string? FaxNumber { get; set; }

            [JsonPropertyName("phone")]
            public string? PhoneNumber { get; set; }

            [JsonPropertyName("email")]
            public string? EmailAddress { get; set; }

            [JsonPropertyName("contact")]
            public string? Contact { get; set; }

            [JsonPropertyName("assets_count")]
            public int AssetsCount { get; set; }

            [JsonPropertyName("accessories_count")]
            public int AccessoriesCount { get; set; }

            [JsonPropertyName("licenses_count")]
            public int LicensesCount { get; set; }

            [JsonPropertyName("notes")]
            public string? Notes { get; set; }

            [JsonPropertyName("created_at")]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName("updated_at")]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName("available_actions")]
            public Actions AvailableActions { get; set; }

            internal struct Actions
            {
                [JsonPropertyName("update")]
                public bool Update { get; set; }

                [JsonPropertyName("delete")]
                public bool Delete {get; set; }

                internal void Deconstruct(out bool update, out bool delete)
                    => (update, delete) = (Update, Delete);
            }
        }
    }
}
