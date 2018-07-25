using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert an Asset identity into an Asset object.</para>
    /// </summary>
    public class AssetIdentity: IObjectIdentity
    {
        /// <summary>
        /// Fetches a single Asset by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of an asset.</param>
        public AssetIdentity(int id)
        {
            Asset = ApiHelper.Instance.AssetManager.Get(id);
            Identity = id.ToString();
        }
        /// <summary>
        /// Fetches a single Asset, checking first for by Asset Tag, then by Serial, then by Name.
        /// </summary>
        /// <param name="name_tag_serial">An Asset Tag, Serial, or Name for an asset.</param>
        public AssetIdentity(string name_tag_serial)
        {
            Asset = ApiHelper.Instance.AssetManager.GetByAssetTag(name_tag_serial)
                        ?? ApiHelper.Instance.AssetManager.GetBySerial(name_tag_serial)
                        ?? ApiHelper.Instance.AssetManager.Get(name_tag_serial);
            Identity = name_tag_serial;
        }
        /// <summary>
        /// Re-fetches an Asset by its internal Id.
        /// </summary>
        /// <param name="asset">An Asset object.</param>
        public AssetIdentity(Asset asset) : this((int) asset.Id)
        {
            // Uses Id constructor
        }

        /// <summary>
        /// The fetched Asset.
        /// </summary>
        /// <value>An asset object, if the Identity was valid, else null.</value>
        internal Asset Asset { get; private set; }

        /// <summary>
        /// The Identity used to fetch the Asset; for use in debugging and error reporting.
        /// </summary>
        /// <value>The Identity value used to fetch the Asset from the system represented as a string.</value>
        internal string Identity { get; private set; }

        public bool IsNull => Asset == null;
    }
}