---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Find-SnipeAsset

## SYNOPSIS
Finds a Snipe IT asset.

## SYNTAX

### Default (Default)
```
Find-SnipeAsset
 [-StatusLabel <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-StatusMeta <FilterStatusMeta>] [-IsRequestable <Boolean>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 [-OrderNumber <String>] [[-SearchString] <String>] [-SortOrder <SearchOrder>]
 [-SortColumn <AssetSearchColumn>] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### AssignedToUser
```
Find-SnipeAsset
 [-StatusLabel <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-StatusMeta <FilterStatusMeta>] [-IsRequestable <Boolean>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 [-OrderNumber <String>] [-AssignedUser <UserBinding>] [[-SearchString] <String>] [-SortOrder <SearchOrder>]
 [-SortColumn <AssetSearchColumn>] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### AssignedToLocation
```
Find-SnipeAsset
 [-StatusLabel <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-StatusMeta <FilterStatusMeta>] [-IsRequestable <Boolean>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 [-OrderNumber <String>]
 [-AssignedLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [[-SearchString] <String>] [-SortOrder <SearchOrder>] [-SortColumn <AssetSearchColumn>] [-IncludeTotalCount]
 [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### AssignedToAsset
```
Find-SnipeAsset
 [-StatusLabel <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-StatusMeta <FilterStatusMeta>] [-IsRequestable <Boolean>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 [-OrderNumber <String>] [-AssignedAsset <AssetBinding>] [[-SearchString] <String>] [-SortOrder <SearchOrder>]
 [-SortColumn <AssetSearchColumn>] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
The Find-Asset cmdlet finds asset objects by filter.

## EXAMPLES

### Example 1
```powershell
PS C:\> Find-Asset
```

Finds all assets.

### Example 2
```powershell
PS C:\> Find-Asset "PotatoPeeler"
```

Finds assets that match the search string "PotatoPeeler".

## PARAMETERS

### -AssignedAsset
Only search for assets assigned to this asset.

```yaml
Type: AssetBinding
Parameter Sets: AssignedToAsset
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AssignedLocation
Only search for assets assigned to this location.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]
Parameter Sets: AssignedToLocation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AssignedUser
Only search for assets assigned to this user.

```yaml
Type: UserBinding
Parameter Sets: AssignedToUser
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Category
Only search for assets in this category.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Company
Only search for assets owned by this company.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Depreciation
Only search for assets with this depreciation.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Reports the number of objects in the data set (an integer) followed by the objects.
If the cmdlet cannot determine the total count, it returns 'Unknown total count'.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsRequestable
Only search for assets with that are requestable (or not).

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Only search for assets at this location.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Manufacturer
Only search for assets built by this manufacturer.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Model
Only search for assets of this model.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OrderNumber
Only search for assets from this order.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SearchString
The string to search for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SortColumn
On which column to sort the data.

```yaml
Type: AssetSearchColumn
Parameter Sets: (All)
Aliases:
Accepted values: Id, Name, AssetTag, ModelNumber, LastCheckOut, Notes, ExpectedCheckIn, OrderNumber, ImageUri, AssignedTo, CreatedAt, UpdatedAt, PurchaseDate, PurchaseCost, LastAuditDate, NextAuditDate, WarrantyMonths, CheckOutCounter, CheckInCounter, RequestsCounter

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SortOrder
Which way to sort the data.

```yaml
Type: SearchOrder
Parameter Sets: (All)
Aliases:
Accepted values: Ascending, Descending

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusLabel
Only search for assets with this status.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StatusMeta
Filter by status meta, e.g. Deployed or Archived or Requestable.

```yaml
Type: FilterStatusMeta
Parameter Sets: (All)
Aliases:
Accepted values: RTD, Archived, Undeployable, Deployed, Deleted, Requestable

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Supplier
Only search for assets purchased from this supplier.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### SnipeSharp.Models.Asset

## NOTES

## RELATED LINKS
