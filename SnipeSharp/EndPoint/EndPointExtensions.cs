using System;
using System.Collections.Generic;
using SnipeSharp.EndPoint;
using SnipeSharp.Exceptions;
using SnipeSharp.Filters;
using SnipeSharp.Models;

namespace SnipeSharp
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
            => endPoint.Api.RequestManager.GetAll<AccessoryCheckOut>($"{endPoint.EndPointInfo.BaseUri}/{accessory.Id}/checkedout").RethrowExceptionIfAny().Value;
        #endregion
        #region Asset
        /// <summary>
        /// Check out an asset.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="request">An asset check-out request.</param>
        /// <returns></returns>
        public static RequestResponse<ApiObject> CheckOut(this EndPoint<Asset> endPoint, AssetCheckOutRequest request)
            => endPoint.Api.RequestManager.Post<AssetCheckOutRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkout", request).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Check in an asset with an optional message.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="asset">An asset to check in.</param>
        /// <param name="note">An optional message for the check-in log.</param>
        /// <returns></returns>
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
        public static RequestResponse<ApiObject> CheckIn(this EndPoint<Asset> endPoint, AssetCheckInRequest request)
            => endPoint.Api.RequestManager.Post<AssetCheckInRequest, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/{request.Asset.Id}/checkin", request).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Marks an asset as audited.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="asset">An asset to audit.</param>
        /// <param name="location">The location of the audit.</param>
        /// <param name="nextAuditDate">The date of the next audit.</param>
        /// <param name="notes">A note for the audit log.</param>
        /// <returns>An <see cref="AssetAudit"/> with some fields missing, and the request status.</returns>
        public static RequestResponse<AssetAudit> Audit(this EndPoint<Asset> endPoint, Asset asset, Location location = null, DateTime? nextAuditDate = null, string notes = null)
        {
            var audit = new AssetAudit
            {
                Asset = asset,
                Location = location,
                NextAuditDate = nextAuditDate,
                Note = notes
            };
            return endPoint.Api.RequestManager.Post<AssetAudit>($"{endPoint.EndPointInfo.BaseUri}/audit", audit).RethrowExceptionIfAny().Value;
        }

        /// <summary>
        /// Retrieve an asset by its tag.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="tag">An asset tag.</param>
        /// <returns>The asset with the corresponding asset tag.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If no asset with that tag could be found, or there was another error with the API.</exception>
        public static Asset GetByTag(this EndPoint<Asset> endPoint, string tag)
            => GetByTagOptional(endPoint, tag).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Retrieve an asset by its tag, but do not throw any errors.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="tag">An asset tag.</param>
        /// <returns>A tuple containing the asset (if it was found), and any error (if there was one).</returns>
        public static ApiOptionalResponse<Asset> GetByTagOptional(this EndPoint<Asset> endPoint, string tag)
            => endPoint.Api.RequestManager.Get<Asset>($"{endPoint.EndPointInfo.BaseUri}/bytag/{tag}");

        /// <summary>
        /// Retrieve assets by serial number.
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="serial">A serial number.</param>
        /// <returns>The assets with the corresponding serial number.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If no asset with that serial could be found, or there was another error with the API.</exception>
        public static ResponseCollection<Asset> FindBySerial(this EndPoint<Asset> endPoint, string serial)
            => FindBySerialOptional(endPoint, serial).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Retrieve an asset by its serial, alongside any error
        /// </summary>
        /// <param name="endPoint">An endpoint for assets.</param>
        /// <param name="serial">A serial number.</param>
        /// <returns>An optional response containing the asset (if it was found), and any error (if there was one).</returns>
        public static ApiOptionalResponse<ResponseCollection<Asset>> FindBySerialOptional(this EndPoint<Asset> endPoint, string serial)
            => endPoint.Api.RequestManager.Get<ResponseCollection<Asset>>($"{endPoint.EndPointInfo.BaseUri}/byserial/{serial}");
        #endregion
        #region Component
        /// <summary>
        /// Get the list of component assignees for a component.
        /// </summary>
        /// <param name="endPoint">An endpoint for components.</param>
        /// <param name="component">The component to get the assignee list of.</param>
        /// <returns>A ResponseCollection list of ComponentAssignees.</returns>
        public static ResponseCollection<ComponentAssignee> GetAssignedAssets(this EndPoint<Component> endPoint, Component component)
            => endPoint.Api.RequestManager.GetAll<ComponentAssignee>($"{endPoint.EndPointInfo.BaseUri}/{component.Id}/assets").RethrowExceptionIfAny().Value;
        #endregion
        #region CustomField
        /// <summary>
        /// Associates a custom field with a custom field set.
        /// </summary>
        /// <param name="endPoint">An endpoint for fields.</param>
        /// <param name="field">The field to associate.</param>
        /// <param name="fieldSet">The field set to associate to.</param>
        /// <param name="required">Is the field required?</param>
        /// <param name="order">The field's order in the set.</param>
        /// <returns>The request status.</returns>
        public static RequestResponse<FieldSet> Associate(this EndPoint<CustomField> endPoint, CustomField field, FieldSet fieldSet, bool required = false, int? order = null)
        {
            var obj = new CustomFieldAssociation { FieldSet = fieldSet };
            if(required)
                obj.IsRequired = true;
            if(!(order is null))
                obj.Order = order.Value;
            return endPoint.Api.RequestManager.Post<CustomFieldAssociation, FieldSet>($"{endPoint.EndPointInfo.BaseUri}/{field.Id}/associate", obj).RethrowExceptionIfAny().Value;
        }

        /// <summary>
        /// Disassociates a custom field from a custom field set.
        /// </summary>
        /// <param name="endPoint">An endpoint for fields.</param>
        /// <param name="field">The field to disassociate.</param>
        /// <param name="fieldSet">The field set to disassociate from.</param>
        /// <returns>The request status.</returns>
        public static RequestResponse<FieldSet> Disassociate(this EndPoint<CustomField> endPoint, CustomField field, FieldSet fieldSet)
            => endPoint.Api.RequestManager.Post<CustomFieldAssociation, FieldSet>($"{endPoint.EndPointInfo.BaseUri}/{field.Id}/disassociate", new CustomFieldAssociation { FieldSet = fieldSet }).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Reorders the fields in a field set.
        /// </summary>
        /// <param name="endPoint">An endpoint for fields.</param>
        /// <param name="fieldSet">The fieldset to reorder.</param>
        /// <param name="customFields">The fields of the field set in their new order.</param>
        /// <returns>The request status.</returns>
        public static RequestResponse<ApiObject> Reorder(this EndPoint<CustomField> endPoint, FieldSet fieldSet, ICollection<CustomField> customFields)
        {
            var arr = new CustomField[customFields.Count];
            customFields.CopyTo(arr, 0);
            return Reorder(endPoint, fieldSet, arr);
        }

        /// <summary>
        /// Reorders the fields in a field set.
        /// </summary>
        /// <param name="endPoint">An endpoint for fields.</param>
        /// <param name="fieldSet">The fieldset to reorder.</param>
        /// <param name="customFields">The fields of the field set in their new order.</param>
        /// <returns>The request status.</returns>
        public static RequestResponse<ApiObject> Reorder(this EndPoint<CustomField> endPoint, FieldSet fieldSet, params CustomField[] customFields)
            => endPoint.Api.RequestManager.Post<CustomFieldReordering, ApiObject>($"{endPoint.EndPointInfo.BaseUri}/fieldsets/{fieldSet.Id}/order", new CustomFieldReordering { Fields = customFields }).RethrowExceptionIfAny().Value;


        #endregion
        #region FieldSet
        /// <summary>
        /// Retrieve the fields of a fieldset.
        /// </summary>
        /// <param name="endPoint">An endpoint for field sets.</param>
        /// <param name="fieldSet">The fieldset to retrieve fields from.</param>
        /// <returns>A response collection with the request status and fields.</returns>
        public static ResponseCollection<CustomField> GetFields(this EndPoint<FieldSet> endPoint, FieldSet fieldSet)
            => endPoint.Api.RequestManager.GetAll<CustomField>($"{endPoint.EndPointInfo.BaseUri}/{fieldSet.Id}/fields").RethrowExceptionIfAny().Value;

        /// <summary>
        /// Retrieve the fields of a fieldset with the default values of the fields for a given model.
        /// </summary>
        /// <param name="endPoint">An endpoint for field sets.</param>
        /// <param name="model">The model to retrieve fields with default values for.</param>
        /// <returns>A response collection with the request status and fields with default values.</returns>
        public static ResponseCollection<CustomField> GetFieldsWithDefaults(this EndPoint<FieldSet> endPoint, Model model)
            => endPoint.Api.RequestManager.GetAll<CustomField>($"{endPoint.EndPointInfo.BaseUri}/{model.FieldSet.Id}/fields/{model.Id}").RethrowExceptionIfAny().Value;
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
            => endPoint.Api.RequestManager.GetAll<LicenseSeat>($"{endPoint.EndPointInfo.BaseUri}/{license.Id}/seats").RethrowExceptionIfAny().Value;
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
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/assetlist").RethrowExceptionIfAny().Value;

        /// <summary>
        /// Checks if a specific status label is a deployable type.
        /// </summary>
        /// <param name="endPoint">An endpoint for status labels.</param>
        /// <param name="label">A status label to check.</param>
        /// <returns>True if the label is a deployable type, otherwise false.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API, or the status label does not exist.</exception>
        public static bool IsDeployable(this EndPoint<StatusLabel> endPoint, StatusLabel label)
            => endPoint.Api.RequestManager.GetRaw($"{endPoint.EndPointInfo.BaseUri}/{label.Id}/deployable").Trim() == "1";

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
            => endPoint.Api.RequestManager.GetAll<Asset>($"{endPoint.EndPointInfo.BaseUri}/{user.Id}/assets").RethrowExceptionIfAny().Value;

        /// <summary>
        /// Get the current user of the API.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <returns>An optional response representing the user information for the current user of the API, or any error thrown.</returns>
        public static ApiOptionalResponse<User> MeOptional(this EndPoint<User> endPoint)
            => endPoint.Api.RequestManager.Get<User>($"{endPoint.EndPointInfo.BaseUri}/me");

        /// <summary>
        /// Get the current user of the API.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <returns>The user information for the current user of the API.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API.</exception>
        public static User Me(this EndPoint<User> endPoint)
            => MeOptional(endPoint).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Gets a user by their username.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="username">The username of the user to search for.</param>
        /// <param name="filter">The search filter to use (the username will override the search string)</param>
        /// <returns>The user information for the user with the provided username.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API or the user was not found.</exception>
        public static User GetByUserName(this EndPoint<User> endPoint, string username, UserSearchFilter filter = null)
            => GetByUserNameOptional(endPoint, username, filter).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="email">The email address of the user to search for.</param>
        /// <param name="filter">The search filter to use (the email will override the search string)</param>
        /// <returns>The user information for the user with the provided email address.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API or the user was not found.</exception>
        public static User GetByEmailAddress(this EndPoint<User> endPoint, string email, UserSearchFilter filter = null)
            => GetByEmailAddressOptional(endPoint, email, filter).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Gets a user by their username, but do not throw any errors.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="username">The username of the user to search for.</param>
        /// <param name="filter">The search filter to use (the username will override the search string)</param>
        /// <returns>An optional response containing the user (if it was found), and any error (if there was one).</returns>
        public static ApiOptionalResponse<User> GetByUserNameOptional(this EndPoint<User> endPoint, string username, UserSearchFilter filter = null)
        {
            filter = filter ?? new UserSearchFilter();
            filter.Search = username;
            var results = endPoint.FindAllOptional(filter);
            if(!results.HasValue)
                return new ApiOptionalResponse<User> { Exception = results.Exception };
            foreach(var user in results.Value)
                if(user.UserName == username)
                    return new ApiOptionalResponse<User> { Value = user };
            return new ApiOptionalResponse<User> { Exception = new ApiErrorException($"No user was found by the username \"{username}\".") };
        }

        /// <summary>
        /// Gets a user by their email address, but do not throw any errors.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="email">The email address of the user to search for.</param>
        /// <param name="filter">The search filter to use (the email will override the search string)</param>
        /// <returns>An optional response containing the user (if it was found), and any error (if there was one).</returns>
        public static ApiOptionalResponse<User> GetByEmailAddressOptional(this EndPoint<User> endPoint, string email, UserSearchFilter filter = null)
        {
            filter = filter ?? new UserSearchFilter();
            filter.Search = email;
            var results = endPoint.FindAllOptional(filter);
            if(!results.HasValue)
                return new ApiOptionalResponse<User> { Exception = results.Exception };
            foreach(var user in results.Value)
                if(user.EmailAddress == email)
                    return new ApiOptionalResponse<User> { Value = user };
            return new ApiOptionalResponse<User> { Exception = new ApiErrorException($"No user was found by the email address \"{email}\".") };
        }

        /// <summary>
        /// Get the accessories checked out by a user.
        /// </summary>
        /// <param name="endPoint">An endpoint for users.</param>
        /// <param name="user">The user to get the checked-out accessroies of.</param>
        /// <returns>A ResponseCollection list of Accessories.</returns>
        public static ResponseCollection<Accessory> GetAssignedAccessories(this EndPoint<User> endPoint, User user)
            => endPoint.Api.RequestManager.GetAll<Accessory>($"{endPoint.EndPointInfo.BaseUri}/{user.Id}/accessories").RethrowExceptionIfAny().Value;
        #endregion
    }
}
