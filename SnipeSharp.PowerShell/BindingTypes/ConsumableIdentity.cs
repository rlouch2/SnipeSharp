using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Consumable identity into a Consumable object.</para>
    /// </summary>
    public class ConsumableIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Consumable by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Consumable.</param>
        public ConsumableIdentity(int id)
        {
            Consumable = ApiHelper.Instance.ConsumableManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Consumable by Name.
        /// </summary>
        /// <param name="name">A Name for a Consumable.</param>
        public ConsumableIdentity(string name)
        {
            Consumable = ApiHelper.Instance.ConsumableManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Consumable by its internal Id.
        /// </summary>
        /// <param name="asset">A Consumable object.</param>
        public ConsumableIdentity(Consumable consumable) : this((int) consumable.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Consumable.
        /// </summary>
        /// <value>A Consumable object, if the Identity was valid, else null.</value>
        internal Consumable Consumable { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Consumable; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Consumable from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Consumable == null;
    }
}