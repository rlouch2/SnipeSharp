using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Category identity into a Category object.</para>
    /// </summary>
    public class CategoryIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Category by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Category.</param>
        public CategoryIdentity(int id)
        {
            Category = ApiHelper.Instance.CategoryManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Category by Name.
        /// </summary>
        /// <param name="name">A Name for a Category.</param>
        public CategoryIdentity(string name)
        {
            Category = ApiHelper.Instance.CategoryManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Category by its internal Id.
        /// </summary>
        /// <param name="asset">A Category object.</param>
        public CategoryIdentity(Category category) : this((int) category.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Category.
        /// </summary>
        /// <value>A Category object, if the Identity was valid, else null.</value>
        internal Category Category { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Category; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Category from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Category == null;
    }
}