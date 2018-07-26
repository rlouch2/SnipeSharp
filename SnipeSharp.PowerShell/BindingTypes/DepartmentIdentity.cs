using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Department identity into a Department object.</para>
    /// </summary>
    public class DepartmentIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Department by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Department.</param>
        public DepartmentIdentity(int id)
        {
            Department = ApiHelper.Instance.DepartmentManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Department by Name.
        /// </summary>
        /// <param name="name">A Name for a Department.</param>
        public DepartmentIdentity(string name)
        {
            Department = ApiHelper.Instance.DepartmentManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Department by its internal Id.
        /// </summary>
        /// <param name="asset">A Department object.</param>
        public DepartmentIdentity(Department category) : this((int) category.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Department.
        /// </summary>
        /// <value>A Department object, if the Identity was valid, else null.</value>
        internal Department Department { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Department; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Department from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Department == null;
    }
}