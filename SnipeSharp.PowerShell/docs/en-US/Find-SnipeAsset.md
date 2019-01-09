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

```
Find-SnipeAsset [[-SearchString] <String>] [-SortOrder <SearchOrder>] [-SortColumn <AssetSearchColumn>]
 [-NoEnumerate] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
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

### -NoEnumerate
If present, return the result as a ResponseCollection rather than enumerating.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### SnipeSharp.Models.Asset

## NOTES

## RELATED LINKS
