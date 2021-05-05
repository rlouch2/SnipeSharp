using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(LocationConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class Location: IApiObject<Location>, IEnumerable<Stub<Location>>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.IMAGE)]
        public Uri? Image { get; }

        [DeserializeAs(Static.Location.ADDRESS)]
        public string? Address { get; }

        [DeserializeAs(Static.Location.ADDRESS2)]
        public string? Address2 { get; }

        [DeserializeAs(Static.Location.CITY)]
        public string? City { get; }

        [DeserializeAs(Static.Location.STATE)]
        public string? State { get; }

        [DeserializeAs(Static.Location.COUNTRY)]
        public string? Country { get; }

        [DeserializeAs(Static.Location.ZIP)]
        public string? ZipCode { get; }

        [DeserializeAs(Static.Count.ASSIGNED_ASSETS, IsNonNullable = true)]
        public int AssignedAssetsCount { get; }

        [DeserializeAs(Static.Count.ASSETS, IsNonNullable = true)]
        public int AssetsCount { get; }

        [DeserializeAs(Static.Count.USERS, IsNonNullable = true)]
        public int UsersCount { get; }

        [DeserializeAs(Static.CURRENCY)]
        public string? Currency { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.Location.PARENT)]
        public Stub<Location>? ParentLocation { get; }

        [DeserializeAs(Static.MANAGER)]
        public StubUser? Manager { get; }

        [DeserializeAs(Static.Location.CHILDREN)]
        public Stub<Location>[] ChildLocations { get; }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialLocation.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
        }

        IEnumerator<Stub<Location>> IEnumerable<Stub<Location>>.GetEnumerator()
            => ((IEnumerable<Stub<Location>>)ChildLocations).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ChildLocations.GetEnumerator();

        internal Location(PartialLocation partial)
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
}
