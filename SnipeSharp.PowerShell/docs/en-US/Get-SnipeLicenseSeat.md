---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeLicenseSeat

## SYNOPSIS
Gets the License Seats of a Snipe IT License.

## SYNTAX

```
Get-SnipeLicenseSeat [-License] <ObjectBinding`1[]> [-SortOrder <SearchOrder>]
 [-SortColumn <LicenseSeatSearchColumn>] [-NoEnumerate] [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-LicenseSeat cmdlet gets, for each license provided, the license seat objects associated with that license.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-LicenseSeat License12
```

Retrieves the license seats for the license License12.

### Example 2
```powershell
PS C:\> Get-LicenseSeat License12, License11
```

Retrieves the license seats for the licenses License12 and License11.

## PARAMETERS

### -First
Gets only the specified number of objects. Enter the number of objects to get.

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
Reports the total number of objects in the data set (an integer) followed by the selected objects. If the cmdlet cannot determine the total count, it displays "Unknown total count." The integer has an Accuracy property that indicates the reliability of the total count value. The value of Accuracy ranges from 0.0 to 1.0 where 0.0 means that the cmdlet could not count the objects, 1.0 means that the count is exact, and a value between 0.0 and 1.0 indicates an increasingly reliable estimate.

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

### -License
The license to retrieve the seats of.

```yaml
Type: ObjectBinding`1[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -Skip
Ignores the specified number of objects and then gets the remaining objects. Enter the number of objects to skip.

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
Type: LicenseSeatSearchColumn
Parameter Sets: (All)
Aliases:
Accepted values: Id, Department

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.License, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]][]

## OUTPUTS

### SnipeSharp.Models.LicenseSeat

## NOTES

## RELATED LINKS
