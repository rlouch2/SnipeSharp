using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.EndPoint
{
    public static class EndPointExtensions
    {
        #region Accessory
        public static ResponseCollection<AccessoryCheckOut> GetCheckedOut(this EndPoint<Accessory> endPoint, Accessory accessory)
            => endPoint.Api.RequestManager.GetAll<AccessoryCheckOut>($"{endPoint.EndPointInfo.BaseUri}/{accessory.Id}/checkedout");
        #endregion
        #region Asset
        public static RequestResponse<ApiObject> CheckOut(this EndPoint<Asset> endPoint, AssetCheckOutRequest request)
            => endPoint.Api.RequestManager.Post<AssetCheckOutRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkout", request);

        public static RequestResponse<ApiObject> CheckIn(this EndPoint<Asset> endPoint, Asset asset, string note = null, Location location = null)
            => endPoint.Api.RequestManager.Post<AssetCheckInRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{asset.Id}/checkin", new AssetCheckInRequest {
                Note = note,
                Location = location
            });

        // TODO: return type, signature
        public static object Audit(this EndPoint<Asset> endPoint, Asset asset)
        {
            //TODO
            return null;
        }

        public static Asset GetByTag(this EndPoint<Asset> endPoint, string tag)
            => endPoint.Api.RequestManager.Get<Asset>($"{endPoint.EndPointInfo.BaseUri}/bytag/{tag}");
        
        public static Asset GetBySerial(this EndPoint<Asset> endPoint, string serial)
            => endPoint.Api.RequestManager.Get<Asset>($"{endPoint.EndPointInfo.BaseUri}/byserial/{serial}");
        #endregion
        #region Component
        public static ResponseCollection<ComponentAsset> GetAssignedAssets(this EndPoint<Component> endPoint, Component component)
            => endPoint.Api.RequestManager.GetAll<ComponentAsset>($"{endPoint.EndPointInfo.BaseUri}/{component.Id}/assets");
        #endregion
        #region CustomField
        //TODO: return type
        public static object Associate(this EndPoint<CustomField> endPoint, CustomField field, FieldSet fieldSet)
        {
            // TODO
            return null;
        }

        //TODO: return type
        public static object Disassociate(this EndPoint<CustomField> endPoint, CustomField field, FieldSet fieldSet)
        {
            // TODO
            return null;
        }

        //TODO: return type, signature
        public static object Redorder(this EndPoint<CustomField> endPoint, CustomField field, FieldSet fieldSet)
        {
            // TODO
            return null;
        }
        #endregion
        #region License
        public static ResponseCollection<LicenseSeat> GetSeats(this EndPoint<License> endPoint, License license)
            => endPoint.Api.RequestManager.GetAll<LicenseSeat>($"{endPoint.EndPointInfo.BaseUri}/{license.Id}/seats");
        #endregion
        #region Location
        // TODO: /locations/{id}/assets and /locations/{id}/users when those aren't broken.
        #endregion
        #region Model
        // TODO: /models/assets when that isn't broken
        #endregion
        #region StatusLabel
        public static ResponseCollection<Asset> GetAssets(this EndPoint<StatusLabel> endPoint, StatusLabel label)
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/assetlist");

        public static bool IsDeployable(this EndPoint<StatusLabel> endPoint, StatusLabel label)
            => endPoint.Api.RequestManager.GetRaw($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/deployable") == "1";

        public static StatusLabel FromAssetStatus(this EndPoint<StatusLabel> endPoint, AssetStatus status)
            => endPoint.Get(status.StatusId);
        public static AssetStatus ToAssetStatus(this StatusLabel label)
            => new AssetStatus { StatusId = label.Id };
        #endregion
        #region User
        public static ResponseCollection<Asset> GetAssignedAssets(this EndPoint<User> endPoint, User user)
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{user.Id}/assetlist");
        #endregion
    }
}