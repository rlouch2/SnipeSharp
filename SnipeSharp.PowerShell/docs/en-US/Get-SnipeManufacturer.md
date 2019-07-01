---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeManufacturer

## SYNOPSIS
Gets a Snipe IT manufacturer.

## SYNTAX

### All (Default)
```
Get-SnipeManufacturer [-Deleted <Boolean>] [-NoEnumerate] [<CommonParameters>]
```

### ByInternalId
```
Get-SnipeManufacturer [-Deleted <Boolean>] -InternalId <Int32[]> [-NoEnumerate] [<CommonParameters>]
```

### ByName
```
Get-SnipeManufacturer [-Deleted <Boolean>] -Name <String[]> [-NoEnumerate] [<CommonParameters>]
```

### ByIdentity
```
Get-SnipeManufacturer [-Deleted <Boolean>] [-Identity] <ObjectBinding`1[]> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-Manufacturer cmdlet gets one or more manufacturer objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-Manufacturer 14
```

Retrieve an manufacturer by its Internal Id.

### Example 2
```powershell
PS C:\> Get-Manufacturer Manufacturer4368
```

Retrieve an manufacturer explicitly by its Name.

### Example 3
```powershell
PS C:\> 1..100 | Get-Manufacturer
```

Retrieve the first 100 manufacturers by their Snipe IT internal Id numbers.

## PARAMETERS

### -Deleted
Find deleted manufacturers, or non-deleted manufacturers?

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
An identity for an object.

```yaml
Type: ObjectBinding`1[]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -InternalId
If present, return the result as a ResponseCollection rather than enumerating.

```yaml
Type: Int32[]
Parameter Sets: ByInternalId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Object.

```yaml
Type: String[]
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32[]

### System.String[]

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Manufacturer, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]][]

## OUTPUTS

### SnipeSharp.Models.Manufacturer

## NOTES

## RELATED LINKS

[Find-SnipeManufacturer](Find-SnipeManufacturer.md)
