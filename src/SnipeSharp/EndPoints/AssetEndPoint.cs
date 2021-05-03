using System;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class AssetEndPoint: EndPoint<Company> {
        internal AssetEndPoint(SnipeItApi api): base(api, "hardware"){}

        public Task<Asset?> GetByTagAsync(string tag)
            => Api.Client.Get<Asset>($"{BaseUri}/bytag/{tag}");

        public Task<DataTable<Asset>?> FindBySerialNumberAsync(string serial)
            => Api.Client.Get<DataTable<Asset>>($"{BaseUri}/byserial/{serial}");

        public Task<SelectList<Asset>?> SelectAsync(string? search = null, SelectAssetStatusType? statusType = null)
        {
            var joiner = new StringJoiner("&");
            if(null != search)
                joiner.Append($"search={Uri.EscapeUriString(search)}");
            var serializedStatusType = statusType.Serialize();
            if(null != serializedStatusType)
                joiner.Append($"assetStatusType={Uri.EscapeUriString(serializedStatusType)}");
            return Api.Client.Get<SelectList<Asset>>($"{BaseUri}/selectlist{(joiner.JoinedItemsCount > 0 ? "?" : string.Empty)}{joiner}");
        }
    }

    public enum SelectAssetStatusType
    {
        ReadyToDeploy
    }

    internal static class SelectAssetStatusTypeExtensions
    {
        internal static string? Serialize(this SelectAssetStatusType? self)
            => self switch
            {
                SelectAssetStatusType.ReadyToDeploy => "RTD",
                _ => null
            };
    }
}
