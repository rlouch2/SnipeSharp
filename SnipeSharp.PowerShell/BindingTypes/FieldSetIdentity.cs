using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a FieldSet identity into a FieldSet object.</para>
    /// </summary>
    public class FieldSetIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single FieldSet by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a FieldSet.</param>
        public FieldSetIdentity(int id)
        {
            FieldSet = ApiHelper.Instance.FieldSetManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single FieldSet by Name.
        /// </summary>
        /// <param name="name">A Name for a FieldSet.</param>
        public FieldSetIdentity(string name)
        {
            FieldSet = ApiHelper.Instance.FieldSetManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a FieldSet by its internal Id.
        /// </summary>
        /// <param name="asset">A FieldSet object.</param>
        public FieldSetIdentity(FieldSet fieldSet) : this((int) fieldSet.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched FieldSet.
        /// </summary>
        /// <value>A FieldSet object, if the Identity was valid, else null.</value>
        internal FieldSet FieldSet { get; private set; }

        /// <summary>
        /// The Identity used to fetch the FieldSet; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the FieldSet from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => FieldSet == null;
    }
}