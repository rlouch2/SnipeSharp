using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a User identity into a User object.</para>
    /// </summary>
    public class UserIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single User by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a User.</param>
        public UserIdentity(int id)
        {
            User = ApiHelper.Instance.UserManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single User by Name.
        /// </summary>
        /// <param name="name">A Name for a User.</param>
        public UserIdentity(string name)
        {
            User = ApiHelper.Instance.UserManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a User by its internal Id.
        /// </summary>
        /// <param name="asset">A User object.</param>
        public UserIdentity(User user) : this((int) user.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched User.
        /// </summary>
        /// <value>A User object, if the Identity was valid, else null.</value>
        internal User User { get; private set; }

        /// <summary>
        /// The Identity used to fetch the User; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the User from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => User == null;
    }
}