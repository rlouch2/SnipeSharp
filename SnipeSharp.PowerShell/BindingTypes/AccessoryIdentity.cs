using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Accessory identity into a Accessory object.</para>
    /// </summary>
    public class AccessoryIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Accessory by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Accessory.</param>
        public AccessoryIdentity(int id)
        {
            Accessory = ApiHelper.Instance.AccessoryManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Accessory by Name.
        /// </summary>
        /// <param name="name">A Name for a Accessory.</param>
        public AccessoryIdentity(string name)
        {
            Accessory = ApiHelper.Instance.AccessoryManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Accessory by its internal Id.
        /// </summary>
        /// <param name="accessory">A Accessory object.</param>
        public AccessoryIdentity(Accessory accessory) : this((int) accessory.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Accessory.
        /// </summary>
        /// <value>A Accessory object, if the Identity was valid, else null.</value>
        internal Accessory Accessory { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Accessory; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Accessory from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Accessory == null;
    }
}