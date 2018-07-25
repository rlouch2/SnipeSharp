using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a Model identity into a Model object.</para>
    /// </summary>
    public class ModelIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Model by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a Model.</param>
        public ModelIdentity(int id)
        {
            Model = ApiHelper.Instance.ModelManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single Model by Name.
        /// </summary>
        /// <param name="name">A Name for a Model.</param>
        public ModelIdentity(string name)
        {
            Model = ApiHelper.Instance.ModelManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a Model by its internal Id.
        /// </summary>
        /// <param name="asset">A Model object.</param>
        public ModelIdentity(Model model) : this((int) model.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Model.
        /// </summary>
        /// <value>A Model object, if the Identity was valid, else null.</value>
        internal Model Model { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Model; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Model from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Model == null;
    }
}