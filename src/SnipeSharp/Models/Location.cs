using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    public sealed class Location: IApiObject<Location>, IEnumerable<Stub<Location>>
    {
        public int Id { get; }
        public string Name { get; }
        public Uri? Image { get; }
        public string? Address { get; }
        public string? Address2 { get; }
        public string? City { get; }
        public string? State { get; }
        public string? Country { get; }
        public string? ZipCode { get; }
        public int AssignedAssetsCount { get; }
        public int AssetsCount { get; }
        public int UsersCount { get; }
        public string? Currency { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public Stub<Location>? ParentLocation { get; }
        public StubUser? Manager { get; }
        public Stub<Location>[] ChildLocations { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialLocation.Actions partial)
                => (Update, Delete) = partial;
        }

        IEnumerator<Stub<Location>> IEnumerable<Stub<Location>>.GetEnumerator()
            => ((IEnumerable<Stub<Location>>)ChildLocations).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ChildLocations.GetEnumerator();

        internal Location(Serialization.PartialLocation partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            Image = partial.Image;
            Address = partial.Address;
            Address2 = partial.Address2;
            City = partial.City;
            State = partial.State;
            Country = partial.Country;
            ZipCode = partial.ZipCode;
            AssignedAssetsCount = partial.AssignedAssetsCount;
            AssetsCount = partial.AssetsCount;
            UsersCount = partial.UsersCount;
            Currency = partial.Currency;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            ParentLocation = partial.ParentLocation;
            Manager = partial.Manager;
            ChildLocations = partial.ChildLocations ?? Array.Empty<Stub<Location>>();
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    namespace Serialization
    {
        internal sealed class LocationConverter : JsonConverter<Location>
        {
            public override Location? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialLocation>(ref reader, options);
                if(null == partial)
                    return null;
                return new Location(partial);
            }

            public override void Write(Utf8JsonWriter writer, Location value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialLocation
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("image")]
            public Uri? Image { get; set; }

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

            [JsonPropertyName("assigned_assets_count")]
            public int AssignedAssetsCount { get; set; }

            [JsonPropertyName("assets_count")]
            public int AssetsCount { get; set; }

            [JsonPropertyName("users_count")]
            public int UsersCount { get; set; }

            [JsonPropertyName("currency")]
            public string? Currency { get; set; }

            [JsonPropertyName("created_at")]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName("updated_at")]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName("parent")]
            public Stub<Location>? ParentLocation { get; set; }

            [JsonPropertyName("manager")]
            public StubUser? Manager { get; set; }

            [JsonPropertyName("children")]
            public Stub<Location>[]? ChildLocations { get; set; }

            [JsonPropertyName("available_actions")]
            public Actions AvailableActions { get; set; }

            internal struct Actions
            {
                [JsonPropertyName("update")]
                public bool Update { get; set; }

                [JsonPropertyName("delete")]
                public bool Delete { get; set; }

                internal void Deconstruct(out bool update, out bool delete)
                    => (update, delete) = (Update, Delete);
            }
        }
    }
}
