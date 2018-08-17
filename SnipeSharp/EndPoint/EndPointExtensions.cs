using System;
using System.Collections.Generic;
using SnipeSharp.Exceptions;
using SnipeSharp.Filters;
using SnipeSharp.Models;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// Extension functions for <see cref="EndPoint{T}" /> to fill specific functions for specific EndPoints.
    /// </summary>
    public static class EndPointExtensions
    {
        #region Accessory
        /// <summary>
        /// Get the list of accessory check outs for an accessory.
        /// </summary>
        /// <param name="endPoint">An endpoint for accessories.</param>
        /// <param name="accessory">The accessory to get the check-out list of.</param>
        /// <returns>A ResponseCollection list of AccessoryCheckOuts.</returns>
        public static ResponseCollection<AccessoryCheckOut> GetCheckedOut(this EndPoint<Accessory> endPoint, Accessory accessory)
            => endPoint.Api.RequestManager.GetAll<AccessoryCheckOut>($"{endPoint.EndPointInfo.BaseUri}/{accessory.Id}/checkedout");
        #endregion
        #region Asset
        /// <summary>
        /// Check out an asset.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="request">An asset check-out request.</param>
        /// <returns></returns>
        // TODO: is there a better return type?
        public static RequestResponse<ApiObject> CheckOut(this EndPoint<Asset> endPoint, AssetCheckOutRequest request)
            => endPoint.Api.RequestManager.Post<AssetCheckOutRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkout", request);

        /// <summary>
        /// Check in an asset with an optional message.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="asset">An asset to check in.</param>
        /// <param name="note">An optional message for the check-in log.</param>
        /// <returns></returns>
        // TODO: is there a better return type?
        public static RequestResponse<ApiObject> CheckIn(this EndPoint<Asset> endPoint, Asset asset, string note = null)
            => endPoint.CheckIn(new AssetCheckInRequest(asset){
                AssetName = asset.Name,
                Note = note
            });
        
        /// <summary>
        /// Check in an asset.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="request">An asset check-in request.</param>
        /// <returns></returns>
        // TODO: is there a better return type?
        public static RequestResponse<ApiObject> CheckIn(this EndPoint<Asset> endPoint, AssetCheckInRequest request)
            => endPoint.Api.RequestManager.Post<AssetCheckInRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkin", request);

        // TODO: return type, signature
        public static object Audit(this EndPoint<Asset> endPoint, Asset asset, Location location = null, DateTime? nextAuditDate = null, string notes = null)
        {
            //TODO
            return null;
        }

        /// <summary>
        /// Retrieve an asset by its tag.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="tag">An asset tag.</param>
        /// <returns>The asset with the corresponding asset tag.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If no asset with that tag could be found, or there was another error with the API.</exception>
        public static Asset GetByTag(this EndPoint<Asset> endPoint, string tag)
            => endPoint.Api.RequestManager.Get<Asset>($"{endPoint.EndPointInfo.BaseUri}/bytag/{tag}");
        
        /// <summary>
        /// Retrieve an asset by its tag, but do not throw any errors.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="tag">An asset tag.</param>
        /// <returns>A tuple containing the asset (if it was found), and any error (if there was one).</returns>
        public static (Asset Value, Exception Error) GetByTagOrNull(this EndPoint<Asset> endPoint, string tag)
        {
            try
            {
                var @object = endPoint.GetByTag(tag);
                return (@object, null);
            } catch(Exception e)
            {
                return (null, e);
            }
        }
        
        /// <summary>
        /// Retrieve an asset by its serial.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="serial">A serial number.</param>
        /// <returns>The asset with the corresponding serial number.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If no asset with that serial could be found, or there was another error with the API.</exception>
        public static Asset GetBySerial(this EndPoint<Asset> endPoint, string serial)
            => endPoint.Api.RequestManager.Get<Asset>($"{endPoint.EndPointInfo.BaseUri}/byserial/{serial}");
        
        /// <summary>
        /// Retrieve an asset by its serial, but do not throw any errors.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="serial">A serial number.</param>
        /// <returns>A tuple containing the asset (if it was found), and any error (if there was one).</returns>
        public static (Asset Value, Exception Error) GetBySerialOrNull(this EndPoint<Asset> endPoint, string serial)
        {
            try
            {
                var @object = endPoint.GetBySerial(serial);
                return (@object, null);
            } catch(Exception e)
            {
                return (null, e);
            }
        }
        #endregion
        #region Component
        /// <summary>
        /// Get the list of component assignees for a component.
        /// </summary>
        /// <param name="endPoint">An endpoint for components.</param>
        /// <param name="component">The component to get the assignee list of.</param>
        /// <returns>A ResponseCollection list of ComponentAssignees.</returns>
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
        /// <summary>
        /// Get details for the license seats of a license.
        /// </summary>
        /// <param name="endPoint">An endpoint for licenses.</param>
        /// <param name="license">A license to get the details of.</param>
        /// <returns>A ResponseCollection of LicenseSeats.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API, or the license does not exist.</exception>
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
        /// <summary>
        /// Get the list of assets with a certain status label.
        /// </summary>
        /// <param name="endPoint">An endpoint for status labels.</param>
        /// <param name="label">A status label to look up.</param>
        /// <returns>A ResponseCollection of Assets.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API, or the status label does not exist.</exception>
        public static ResponseCollection<Asset> GetAssets(this EndPoint<StatusLabel> endPoint, StatusLabel label)
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/assetlist");

        /// <summary>
        /// Checks if a specific status label is a deployable type.
        /// </summary>
        /// <param name="endPoint">An endpoint for status labels.</param>
        /// <param name="label">A status label to check.</param>
        /// <returns>True if the label is a deployable type, otherwise false.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API, or the status label does not exist.</exception>
        public static bool IsDeployable(this EndPoint<StatusLabel> endPoint, StatusLabel label)
            => endPoint.Api.RequestManager.GetRaw($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/deployable") == "1";

        /// <summary>
        /// Convert an AssetStatus to a StatusLabel by its Id.
        /// </summary>
        /// <param name="endPoint">An endpoint for status labels.</param>
        /// <param name="status">The AssetStatus to convert.</param>
        /// <returns>The StatusLabel corresponding to the provided AssetStatus.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API, or the status label does not exist.</exception>
        public static StatusLabel FromAssetStatus(this EndPoint<StatusLabel> endPoint, AssetStatus status)
            => endPoint.Get(status.StatusId);
        #endregion
        #region User
        /// <summary>
        /// Get the assets assigned to a user.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="user">The user to get the assigned assets of.</param>
        /// <returns>A ResponseCollection list of Assets.</returns>
        public static ResponseCollection<Asset> GetAssignedAssets(this EndPoint<User> endPoint, User user)
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{user.Id}/assetlist");
        
        /// <summary>
        /// Get the current user of the API.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <returns>The user information for the current user of the API.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API.</exception>
        public static User Me(this EndPoint<User> endPoint)
            => endPoint.Api.RequestManager.Get<User>($"{endPoint.EndPointInfo.BaseUri}/me");

        /// <summary>
        /// Gets a user by their username.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="username">The username of the user to search for.</param>
        /// <returns>The user information for the user with the provided username.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API or the user was not found.</exception>
        public static User GetByUserName(this EndPoint<User> endPoint, string username)
        {
            var results = endPoint.FindAll(new UserSearchFilter(username));
            foreach(var user in results)
                if(user.UserName == username)
                    return user;
            throw new ApiErrorException($"No user was found by the username \"{username}\".");
        }

        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="email">The email address of the user to search for.</param>
        /// <returns>The user information for the user with the provided email address.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API or the user was not found.</exception>
        public static User GetByEmailAddress(this EndPoint<User> endPoint, string email)
        {
            var results = endPoint.FindAll(new UserSearchFilter(email));
            foreach(var user in results)
                if(user.EmailAddress == email)
                    return user;
            throw new ApiErrorException($"No user was found by the email address \"{email}\".");
        }
        
        /// <summary>
        /// Gets a user by their username, but do not throw any errors.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="username">The username of the user to search for.</param>
        /// <returns>A tuple containing the user (if it was found), and any error (if there was one).</returns>
        public static (User Value, Exception Error) GetByUserNameOrNull(this EndPoint<User> endPoint, string username)
        {
            var results = endPoint.FindAll(new UserSearchFilter(username));
            foreach(var user in results)
                if(user.UserName == username)
                    return (user, null);
            return (null, new ApiErrorException($"No user was found by the username \"{username}\"."));
        }
        
        /// <summary>
        /// Gets a user by their email address, but do not throw any errors.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="email">The email address of the user to search for.</param>
        /// <returns>A tuple containing the user (if it was found), and any error (if there was one).</returns>
        public static (User Value, Exception Error) GetByEmailAddressOrNull(this EndPoint<User> endPoint, string email)
        {
            var results = endPoint.FindAll(new UserSearchFilter(email));
            foreach(var user in results)
                if(user.EmailAddress == email)
                    return (user, null);
            return (null, new ApiErrorException($"No user was found by the email address \"{email}\"."));
        }
        #endregion
    }
}
