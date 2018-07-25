using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert a StatusLabel identity into a StatusLabel object.</para>
    /// </summary>
    public class StatusLabelIdentity
    {
        /// <summary>
        /// Fetches a single StatusLabel by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of a StatusLabel.</param>
        public StatusLabelIdentity(int id)
        {
            StatusLabel = ApiHelper.Instance.StatusLabelManager.Get(id);
            Identity = id.ToString();
        }
        
        /// <summary>
        /// Fetches a single StatusLabel by Name.
        /// </summary>
        /// <param name="name">A Name for a StatusLabel.</param>
        public StatusLabelIdentity(string name)
        {
            StatusLabel = ApiHelper.Instance.StatusLabelManager.Get(name);
            Identity = name;
        }

        /// <summary>
        /// Re-fetches a StatusLabel by its internal Id.
        /// </summary>
        /// <param name="asset">A StatusLabel object.</param>
        public StatusLabelIdentity(StatusLabel statusLabel) : this((int) statusLabel.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched StatusLabel.
        /// </summary>
        /// <value>A StatusLabel object, if the Identity was valid, else null.</value>
        internal StatusLabel StatusLabel { get; private set; }

        /// <summary>
        /// The Identity used to fetch the StatusLabel; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the StatusLabel from the system represented as a string.</value>
        internal string Identity { get; private set; }
    }
}