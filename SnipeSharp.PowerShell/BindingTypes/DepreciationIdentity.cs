using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Depreciation identity into a Depreciation object.</para>
    /// </summary>
    public class DepreciationIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Depreciation by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Depreciation.</param>
        public DepreciationIdentity(int id)
        {
            Depreciation = ApiHelper.Instance.DepreciationManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Depreciation by Name.
        /// </summary>
        /// <param name="name">A Name for a Depreciation.</param>
        public DepreciationIdentity(string name)
        {
            Depreciation = ApiHelper.Instance.DepreciationManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Depreciation by its internal Id.
        /// </summary>
        /// <param name="asset">A Depreciation object.</param>
        public DepreciationIdentity(Depreciation category) : this((int) category.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Depreciation.
        /// </summary>
        /// <value>A Depreciation object, if the Identity was valid, else null.</value>
        internal Depreciation Depreciation { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Depreciation; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Depreciation from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Depreciation == null;
    }
}