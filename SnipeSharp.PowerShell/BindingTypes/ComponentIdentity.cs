using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Component identity into a Component object.</para>
    /// </summary>
    public class ComponentIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Component by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Component.</param>
        public ComponentIdentity(int id)
        {
            Component = ApiHelper.Instance.ComponentManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Component by Name.
        /// </summary>
        /// <param name="name">A Name for a Component.</param>
        public ComponentIdentity(string name)
        {
            Component = ApiHelper.Instance.ComponentManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Component by its internal Id.
        /// </summary>
        /// <param name="asset">A Component object.</param>
        public ComponentIdentity(Component component) : this((int) component.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Component.
        /// </summary>
        /// <value>A Component object, if the Identity was valid, else null.</value>
        internal Component Component { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Component; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Component from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Component == null;
    }
}