using System;
using System.Collections.Generic;

namespace SnipeSharp.PowerShell.Enums
{
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

        public static string ToString(this AssetSort sort) => _map[sort];
    }

    public enum AssetSort
    {
        Id,
        Name,
        AssetTag,
        Serial,
        Model,
        ModelNumber,
        LastCheckout,
        Category,
        Manufacturer,
        Notes,
        ExpectedCheckin,
        OrderNumber,
        CompanyName,
        Location,
        Image,
        StatusLabel,
        AssignedTo,
        CreatedAt,
        PurchaseDate,
        PurchaseCost
    }
}