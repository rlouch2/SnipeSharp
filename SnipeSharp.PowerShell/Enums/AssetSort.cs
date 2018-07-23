using System;
using System.Collections.Generic;

namespace SnipeSharp.PowerShell.Enums
{
    /// <summary>
    /// Methods for the <see cref="SnipeSharp.PowerShell.Enums.AssetSort" /> type.
    /// </summary>
    internal static class AssetSortMethods {
        private static Dictionary<AssetSort, string> _map = new Dictionary<AssetSort, string>{
            {AssetSort.Id, "id"},
            {AssetSort.Name, "name"},
            {AssetSort.AssetTag, "asset_tag"},
            {AssetSort.Serial, "serial"},
            {AssetSort.Model, "model"},
            {AssetSort.ModelNumber, "model_number"},
            {AssetSort.LastCheckout, "last_checkout"},
            {AssetSort.Category, "category"},
            {AssetSort.Manufacturer, "manufacturer"},
            {AssetSort.Notes, "notes"},
            {AssetSort.ExpectedCheckin, "expected_checkin"},
            {AssetSort.OrderNumber, "order_number"},
            {AssetSort.CompanyName, "companyName"}, // According to the docs, this one is camelCase, not snake_case >_>
            {AssetSort.Location, "location"},
            {AssetSort.Image, "image"},
            {AssetSort.StatusLabel, "status_label"},
            {AssetSort.AssignedTo, "assigned_to"},
            {AssetSort.CreatedAt, "created_at"},
            {AssetSort.PurchaseDate, "purchase_date"},
            {AssetSort.PurchaseCost, "purchase_cost"}
        };

        /// <summary>
        /// Converts an <see cref="SnipeSharp.PowerShell.Enums.AssetSort" /> into a string comptatible with the Snipe IT API.
        /// </summary>
        /// <param name="sort">A sort column.</param>
        /// <returns>A Snipe IT API-compatible column string.</returns>
        public static string ToString(this AssetSort sort) => _map[sort];
    }

    /// <summary>
    /// Column on which to sort results in SnipeIT.
    /// </summary>
    public enum AssetSort
    {
        /// <summary>Sort assets by Snipe IT Internal Id.</summary>
        Id,
        /// <summary>Sort assets by Name.</summary>
        Name,
        /// <summary>Sort assets by Asset Tag.</summary>
        AssetTag,
        /// <summary>Sort assets by Serial Id.</summary>
        Serial,
        /// <summary>Sort assets by Model name.</summary>
        Model,
        /// <summary>Sort assets by the Snipe IT internal Id of the Model.</summary>
        ModelNumber,
        /// <summary>Sort assets by the the date they were last checked out.</summary>
        LastCheckout,
        /// <summary>Sort assets by the name of the asset's category.</summary>
        Category,
        /// <summary>Sort assets by the name of the Manufacturer.</summary>
        Manufacturer,
        /// <summary>Sort assets by the contents of the Notes field.</summary>
        Notes,
        /// <summary>Sort assets by the next expected check-in date.</summary>
        ExpectedCheckin,
        /// <summary>Sort assets by the order number associated with their purchase.</summary>
        OrderNumber,
        /// <summary>Sort assets by the associated owner company.</summary>
        CompanyName,
        /// <summary>Sort assets by the name of the assigned location or assigned user's location.</summary>
        Location,
        /// <summary>Sort assets by the URL of their picture.</summary>
        Image,
        /// <summary>Sort assets by the name of the status label.</summary>
        StatusLabel,
        /// <summary>Sort assets by the name of the assigned user.</summary>
        AssignedTo,
        /// <summary>Sort assets by the date they were added to the system.</summary>
        CreatedAt,
        /// <summary>Sort assets by the date they were purchased.</summary>
        PurchaseDate,
        /// <summary>Sort assets by their cost.</summary>
        PurchaseCost
    }
}