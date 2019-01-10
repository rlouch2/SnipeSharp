---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Find-SnipeAccessory

## SYNOPSIS
Finds a Snipe IT accessory.

## SYNTAX

```
Find-SnipeAccessory [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [[-SearchString] <String>] [-SortOrder <SearchOrder>] [-SortColumn <AccessorySearchColumn>] [-NoEnumerate]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
The Find-Accessory cmdlet finds accessory objects by filter, company, category, manufacturer, or supplier.

## EXAMPLES

### Example 1
```powershell
PS C:\> Find-Accessory "PotatoPeeler"
```

Finds accessories that match the search string "PotatoPeeler".

### Example 2
```powershell
PS C:\> Find-Accessory -Company $x
```

Finds accessories owned by the company stored in `$x`.

## PARAMETERS

### -Category
Filter by accessory category.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Company
Filter by owning company.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]
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

### -Manufacturer
Filter by manufactuerer.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: AccessorySearchColumn
Parameter Sets: (All)
Aliases:
Accepted values: Id, Name, ModelNumber, Category, CreatedAt, MinimumQuantity, CompanyId, Company

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

### -Supplier
Filter by supplier.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]
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

### SnipeSharp.Models.Accessory

## NOTES

## RELATED LINKS
