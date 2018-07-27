using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.EndPoint
{
    public static class AccessoryEndPointExtensions
    {
        public static ResponseCollection<AccessoryCheckOut> GetCheckedOut(this EndPoint<Accessory> endPoint, Accessory accessory)
            => endPoint.Api.RequestManager.Get<ResponseCollection<AccessoryCheckOut>>($"{endPoint.EndPointInfo.BaseUri}/{accessory.Id}/checkedout");
    }

    public static class AssetEndPointExtensions
    {
        public static RequestResponse CheckOut(this EndPoint<Asset> endPoint, AssetCheckOutRequest request)
        {
            //TODO
            return null;
        }

        public static RequestResponse CheckIn(this EndPoint<Asset> endPoint, Asset asset, string note = null, Location location = null)
            => endPoint.Api.RequestManager.Post($"{endPoint.EndPointInfo.BaseUri}/{asset.Id}/checkin", new AssetCheckInRequest {
                Note = note,
                Location = location
            });

        public static ResponseCollection<Asset> GetAssignedAssets(this EndPoint<StatusLabel> endPoint, StatusLabel label)
            => endPoint.Api.RequestManager.Get<ResponseCollection<Asset>>($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/assetlist");

        public static ResponseCollection<Asset> GetAssignedAssets(this EndPoint<User> endPoint, User user)
            => endPoint.Api.RequestManager.Get<ResponseCollection<Asset>>($"{endPoint.EndPointInfo.BaseUri}/{user.Id}/assetlist");
        //TODO
    }
}