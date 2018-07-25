using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Supplier identity into a Supplier object.</para>
    /// </summary>
    public class SupplierIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Supplier by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Supplier.</param>
        public SupplierIdentity(int id)
        {
            Supplier = ApiHelper.Instance.SupplierManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Supplier by Name.
        /// </summary>
        /// <param name="name">A Name for a Supplier.</param>
        public SupplierIdentity(string name)
        {
            Supplier = ApiHelper.Instance.SupplierManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Supplier by its internal Id.
        /// </summary>
        /// <param name="asset">A Supplier object.</param>
        public SupplierIdentity(Supplier supplier) : this((int) supplier.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Supplier.
        /// </summary>
        /// <value>A Supplier object, if the Identity was valid, else null.</value>
        internal Supplier Supplier { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Supplier; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Supplier from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Supplier == null;
    }
}