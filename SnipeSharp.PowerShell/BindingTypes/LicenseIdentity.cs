using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a License identity into a License object.</para>
    /// </summary>
    public class LicenseIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single License by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a License.</param>
        public LicenseIdentity(int id)
        {
            License = ApiHelper.Instance.LicenseManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single License by Name.
        /// </summary>
        /// <param name="name">A Name for a License.</param>
        public LicenseIdentity(string name)
        {
            License = ApiHelper.Instance.LicenseManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a License by its internal Id.
        /// </summary>
        /// <param name="asset">A License object.</param>
        public LicenseIdentity(License license) : this((int) license.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched License.
        /// </summary>
        /// <value>A License object, if the Identity was valid, else null.</value>
        internal License License { get; private set; }

        /// <summary>
        /// The Identity used to fetch the License; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the License from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => License == null;
    }
}