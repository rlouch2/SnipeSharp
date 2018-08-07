using System;
using System.Collections.Generic;

namespace SnipeSharp.PowerShell.Enums
{
    /// <summary>
    /// Methods for the <see cref="SnipeSharp.PowerShell.Enums.SortColumn" /> type.
    /// </summary>
    internal static class SortColumnMethods {
        private static Dictionary<SortColumn, string> _map = new Dictionary<SortColumn, string>{
            {SortColumn.Id, "id"},
            {SortColumn.Name, "name"},
            {SortColumn.AssetTag, "asset_tag"},
            {SortColumn.Serial, "serial"},
            {SortColumn.Model, "model"},
            {SortColumn.ModelNumber, "model_number"},
            {SortColumn.LastCheckout, "last_checkout"},
            {SortColumn.Category, "category"},
            {SortColumn.Manufacturer, "manufacturer"},
            {SortColumn.Notes, "notes"},
            {SortColumn.ExpectedCheckin, "expected_checkin"},
            {SortColumn.OrderNumber, "order_number"},
            {SortColumn.CompanyName, "companyName"}, // According to the docs, this one is camelCase, not snake_case >_>
            {SortColumn.Location, "location"},
            {SortColumn.Image, "image"},
            {SortColumn.StatusLabel, "status_label"},
            {SortColumn.AssignedTo, "assigned_to"},
            {SortColumn.CreatedAt, "created_at"},
            {SortColumn.PurchaseDate, "purchase_date"},
            {SortColumn.PurchaseCost, "purchase_cost"}
        };

        /// <summary>
        /// Converts an <see cref="SnipeSharp.PowerShell.Enums.SortColumn" /> into a string comptatible with the Snipe IT API.
        /// </summary>
        /// <param name="sort">A sort column.</param>
        /// <returns>A Snipe IT API-compatible column string.</returns>
        public static string ToApiString(this SortColumn sort) => _map[sort];
    }

    /// <summary>
    /// Column on which to sort results in SnipeIT.
    /// </summary>
    public enum SortColumn
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