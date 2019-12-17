using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// An assignment. An asset may be assigned to a <see cref="User" />, a <see cref="Location" />,
    /// or a <see cref="Asset" />. This class wraps all three for the API.
    /// </summary>
    public sealed class AssetAssignedTo : ApiObject
    {
        [JsonConstructor]
        private AssetAssignedTo() { }

        internal AssetAssignedTo(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Type = AssignedToType.User;
        }

        internal AssetAssignedTo(Location location)
        {
            Id = location.Id;
            Name = location.Name;
            Type = AssignedToType.Location;
        }

        internal AssetAssignedTo(Asset asset)
        {
            Id = asset.Id;
            Name = asset.Name;
            Type = AssignedToType.Asset;
        }

        /// <value>The internal Id of the object.</value>
        [Field(DeserializeAs = "id")]
        public int Id { get; private set; }

        /// <value>The name of the object.</value>
        [Field(DeserializeAs = "name")]
        public string Name { get; set; }

        /// <value>The type of object this represents.</value>
        [Field(DeserializeAs = "type")]
        public AssignedToType Type { get; set; }

        /// <inheritdoc />
        public override string ToString()
            => Name ?? Id.ToString();

        [JsonExtensionData]
        private Dictionary<string, JToken> _extensionData { get; set; }

        /// <summary>Extra fields that may have been included with the API response not represented by this model.</summary>
        public Dictionary<string, string> ExtensionData { get; } = new Dictionary<string, string>();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if(null == _extensionData)
                return;
            foreach(var pair in _extensionData)
                ExtensionData[pair.Key] = pair.Value.ToObject<string>();
            _extensionData = null;
        }

        /// <summary>
        /// Converts this object into a stub user object that can be used for checking in.
        /// </summary>
        /// <returns>A stub user object, with only the ID field populated.</returns>
        public User AsUser()
        {
            if(Type != AssignedToType.User)
                throw new InvalidOperationException($"Object {Id} is a \"{Type}\", not a User.");
            var user = new User(Id)
            {
                Name = this.Name
            };
            if(ExtensionData.TryGetValue("username", out var username))
                user.UserName = username;
            if(ExtensionData.TryGetValue("first_name", out var firstName))
                user.FirstName = firstName;
            if(ExtensionData.TryGetValue("last_name", out var lastName))
                user.LastName = lastName;
            if(ExtensionData.TryGetValue("employee_number", out var employeeNumber))
                user.EmployeeNumber = employeeNumber;
            return user;
        }

        /// <summary>
        /// Converts this object into a stub location object that can be used for checking in.
        /// </summary>
        /// <returns>A stub location object, with only the ID field populated.</returns>
        public Location AsLocation()
        {
            if(Type != AssignedToType.Location)
                throw new InvalidOperationException($"Object {Id} is a \"{Type}\", not a Location.");
            return new Location(Id) { Name = this.Name };
        }

        /// <summary>
        /// Converts this object into a stub asset object that can be used for checking in.
        /// </summary>
        /// <returns>A stub asset object, with only the ID field populated.</returns>
        public Asset AsAsset()
        {
            if(Type != AssignedToType.Asset)
                throw new InvalidOperationException($"Object {Id} is a \"{Type}\", not a Asset.");
            return new Asset(Id) { Name = this.Name };
        }
    }
}
