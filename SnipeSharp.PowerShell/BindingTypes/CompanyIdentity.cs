using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Company identity into a Company object.</para>
    /// </summary>
    public class CompanyIdentity
    {
        /// <summary>
        /// Fetches a single Company by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Company.</param>
        public CompanyIdentity(int id)
        {
            Company = ApiHelper.Instance.CompanyManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Company by Name.
        /// </summary>
        /// <param name="name">A Name for a Company.</param>
        public CompanyIdentity(string name)
        {
            Company = ApiHelper.Instance.CompanyManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Company by its internal Id.
        /// </summary>
        /// <param name="asset">A Company object.</param>
        public CompanyIdentity(Company company) : this((int) company.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Company.
        /// </summary>
        /// <value>A Company object, if the Identity was valid, else null.</value>
        internal Company Company { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Company; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Company from the system represented as a string.</value>
        internal string Identity { get; private set; }
    }
}