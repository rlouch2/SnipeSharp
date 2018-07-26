using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.EndPoint
{
    public static class EndPointExtensions
    {
        public static RequestResponse CheckOut(this EndPoint<Asset> endPoint, AssetCheckOutRequest request)
        {
            //TODO
            return null;
        }

        public static RequestResponse CheckIn(this EndPoint<Asset> endPoint, Asset asset, string note = null, Location location = null)
        {
            return endPoint.Api.RequestManager.Post($"{endPoint.EndPointInfo.BaseUri}/{asset.Id}/checkin", new AssetCheckInRequest {
                Note = note,
                Location = location
            });
        }
        //TODO
    }
}