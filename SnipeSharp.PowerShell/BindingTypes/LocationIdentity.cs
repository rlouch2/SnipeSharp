using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Location identity into a Location object.</para>
    /// </summary>
    public class LocationIdentity
    {
        /// <summary>
        /// Fetches a single Location by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Location.</param>
        public LocationIdentity(int id)
        {
            Location = ApiHelper.Instance.LocationManager.Get(id);
            Identity = id.ToString();
        }

        /// <summary>
        /// Fetches a single Location by Name.
        /// </summary>
        /// <param name="name">A Name for a Location.</param>
        public LocationIdentity(string name)
        {
            Location = ApiHelper.Instance.LocationManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Location by its internal Id.
        /// </summary>
        /// <param name="asset">A Location object.</param>
        public LocationIdentity(Location location) : this((int) location.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Location.
        /// </summary>
        /// <value>A Location object, if the Identity was valid, else null.</value>
        internal Location Location { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Location; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Location from the system represented as a string.</value>
        internal string Identity { get; private set; }
    }
}