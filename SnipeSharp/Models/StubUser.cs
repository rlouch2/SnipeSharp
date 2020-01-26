using Newtonsoft.Json;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A stub user, without the full properties of a normal user.
    /// </summary>
    public sealed class StubUser : Stub<User>
    {
        /// <summary>The user's first name.</summary>
        [DeserializeAs("first_name")]
        public string FirstName { get; private set; }

        /// <summary>The user's last name.</summary>
        [DeserializeAs("last_name")]
        public string LastName { get; private set; }

        /// <summary>The user's username.</summary>
        /// <remarks>This value may not be filled.</remarks>
        [DeserializeAs("username")]
        public string UserName { get; private set; }

        /// <summary>The user's employee number.</summary>
        /// <remarks>This value may not be filled.</remarks>
        [DeserializeAs("employee_num")]
        public string EmployeeNumber { get; private set; }

        [JsonConstructor]
        private StubUser() { }

        internal StubUser(int id, string name, string firstName, string lastName, string userName, string employeeNumber)
            : base(id, name)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            EmployeeNumber = employeeNumber;
        }

        /// <summary>
        /// Transform a stub to a full user, if for some reason you need to do that.
        /// </summary>
        public static implicit operator User(StubUser stub) => new User
        {
            Id = stub.Id,
            Name = stub.Name,
            FirstName = stub.FirstName,
            LastName = stub.LastName,
            UserName = stub.UserName,
            EmployeeNumber = stub.EmployeeNumber
        };

        /// <summary>
        /// Transform a full user to a stub, for setting values.
        /// </summary>
        public static implicit operator StubUser(User full) => new StubUser
        {
            Id = full.Id,
            Name = full.Name,
            FirstName = full.FirstName,
            LastName = full.LastName,
            UserName = full.UserName,
            EmployeeNumber = full.EmployeeNumber
        };
    }
}
