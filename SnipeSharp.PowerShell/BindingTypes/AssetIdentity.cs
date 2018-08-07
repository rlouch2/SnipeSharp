using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.EndPoint.EndPointExtensions;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// <para type="description">Used to convert an Asset identity into an Asset object.</para>
    /// </summary>
    public class AssetIdentity: ObjectBinding<Asset>
    {
        /// <summary>
        /// Fetches a single Asset by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of an asset.</param>
        public AssetIdentity(int id) : base(id)
        {
        }

        /// <summary>
        /// Fetches a single Asset, checking first for by Asset Tag, then by Serial, then by Name.
        /// </summary>
        /// <param name="name_tag_serial">An Asset Tag, Serial, or Name for an asset.</param>
        public AssetIdentity(string name_tag_serial)
        {
            // TODO: make this not fail every time.
            Object = ApiHelper.Instance.Assets.GetByTag(name_tag_serial)
                        ?? ApiHelper.Instance.Assets.GetBySerial(name_tag_serial)
                        ?? ApiHelper.Instance.Assets.Get(name_tag_serial);
            Query = name_tag_serial;
        }

        /// <summary>
        /// Re-fetches an Asset by its internal Id.
        /// </summary>
        /// <param name="asset">An Asset object.</param>
        public AssetIdentity(Asset asset) : base(asset)
        {
        }
    }
}