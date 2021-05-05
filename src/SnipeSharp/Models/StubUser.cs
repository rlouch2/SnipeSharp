using System;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(StubUserConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed class StubUser: IApiObject<User>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.User.FIRST_NAME)]
        public string FirstName { get; }

        [DeserializeAs(Static.User.LAST_NAME)]
        public string LastName { get; }

        internal StubUser(PartialStubUser partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            FirstName = partial.FirstName ?? throw new ArgumentNullException(nameof(FirstName));
            LastName = partial.LastName ?? throw new ArgumentNullException(nameof(LastName));
        }

        public override string ToString() => Name;
    }
}
