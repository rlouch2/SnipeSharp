using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.EndPoint
{
    public static class AccessoryEndPointExtensions
    {
        public static ResponseCollection<AccessoryCheckOut> GetCheckedOut(this EndPoint<Accessory> endPoint, Accessory accessory)
            => endPoint.Api.RequestManager.GetAll<AccessoryCheckOut>($"{endPoint.EndPointInfo.BaseUri}/{accessory.Id}/checkedout");
    }

    public static class AssetEndPointExtensions
    {
        public static RequestResponse CheckOut(this EndPoint<Asset> endPoint, AssetCheckOutRequest request)
            => endPoint.Api.RequestManager.Post($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkout", request);

        public static RequestResponse CheckIn(this EndPoint<Asset> endPoint, Asset asset, string note = null, Location location = null)
            => endPoint.Api.RequestManager.Post($"{endPoint.EndPointInfo.BaseUri}/{asset.Id}/checkin", new AssetCheckInRequest {
                Note = note,
                Location = location
            });

        public static ResponseCollection<Asset> GetAssignedAssets(this EndPoint<StatusLabel> endPoint, StatusLabel label)
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/assetlist");

        public static ResponseCollection<Asset> GetAssignedAssets(this EndPoint<User> endPoint, User user)
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{user.Id}/assetlist");
    }

    public static class ComponentEndPointExtensions
    {
        public static ResponseCollection<ComponentAsset> GetAssignedAssets(this EndPoint<Component> endPoint, Component component)
            => endPoint.Api.RequestManager.GetAll<ComponentAsset>($"{endPoint.EndPointInfo.BaseUri}/{component.Id}/assets");
    }
}