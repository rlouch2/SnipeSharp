using System;
using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// Extension functions for <see cref="EndPoint{T}" /> to fill specific functions for specific EndPoints.
    /// </summary>
    public static class EndPointExtensions
    {
        #region Accessory
        public static ResponseCollection<AccessoryCheckOut> GetCheckedOut(this EndPoint<Accessory> endPoint, Accessory accessory)
            => endPoint.Api.RequestManager.GetAll<AccessoryCheckOut>($"{endPoint.EndPointInfo.BaseUri}/{accessory.Id}/checkedout");
        #endregion
        #region Asset
        public static RequestResponse<ApiObject> CheckOut(this EndPoint<Asset> endPoint, AssetCheckOutRequest request)
            => endPoint.Api.RequestManager.Post<AssetCheckOutRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkout", request);

        public static RequestResponse<ApiObject> CheckIn(this EndPoint<Asset> endPoint, Asset asset, string note = null)
            => endPoint.CheckIn(new AssetCheckInRequest(asset){
                AssetName = asset.Name,
                Note = note
            });
        public static RequestResponse<ApiObject> CheckIn(this EndPoint<Asset> endPoint, AssetCheckInRequest request)
            => endPoint.Api.RequestManager.Post<AssetCheckInRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkin", request);

        // TODO: return type, signature
        public static object Audit(this EndPoint<Asset> endPoint, Asset asset, Location location = null, DateTime? nextAuditDate = null, string notes = null)
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
        public static ResponseCollection<ComponentAssignee> GetAssignedAssets(this EndPoint<Component> endPoint, Component component)
            => endPoint.Api.RequestManager.GetAll<ComponentAssignee>($"{endPoint.EndPointInfo.BaseUri}/{component.Id}/assets");
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
        public static object Reorder(this EndPoint<CustomField> endPoint, CustomField field, FieldSet fieldSet)
        {
            // TODO
            return null;
        }
        #endregion
        #region FieldSet
        public static ResponseCollection<CustomField> GetFields(this EndPoint<FieldSet> endPoint, FieldSet fieldSet)
            => endPoint.Api.RequestManager.GetAll<CustomField>($"{endPoint.EndPointInfo.BaseUri}/{fieldSet.Id}/fields");
        public static ResponseCollection<CustomField> GetFieldsWithDefaults(this EndPoint<FieldSet> endPoint, FieldSet fieldSet, Model model)
            => endPoint.Api.RequestManager.GetAll<CustomField>($"{endPoint.EndPointInfo.BaseUri}/{fieldSet.Id}/fields/{model.Id}");
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
        public static User Me(this EndPoint<User> endPoint)
            => endPoint.Api.RequestManager.Get<User>($"{endPoint.EndPointInfo.BaseUri}/me");
        #endregion
    }
}
