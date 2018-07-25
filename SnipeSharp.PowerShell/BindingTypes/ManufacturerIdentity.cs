using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Manufacturer identity into a Manufacturer object.</para>
    /// </summary>
    public class ManufacturerIdentity
    {
        /// <summary>
        /// Fetches a single Manufacturer by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Manufacturer.</param>
        public ManufacturerIdentity(int id)
        {
            Manufacturer = ApiHelper.Instance.ManufacturerManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Manufacturer by Name.
        /// </summary>
        /// <param name="name">A Name for a Manufacturer.</param>
        public ManufacturerIdentity(string name)
        {
            Manufacturer = ApiHelper.Instance.ManufacturerManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Manufacturer by its internal Id.
        /// </summary>
        /// <param name="asset">A Manufacturer object.</param>
        public ManufacturerIdentity(Manufacturer manufacturer) : this((int) manufacturer.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Manufacturer.
        /// </summary>
        /// <value>A Manufacturer object, if the Identity was valid, else null.</value>
        internal Manufacturer Manufacturer { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Manufacturer; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Manufacturer from the system represented as a string.</value>
        internal string Identity { get; private set; }
    }
}