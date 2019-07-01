---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeDepreciation

## SYNOPSIS
Changes the properties of an existing Snipe-IT depreciation.

## SYNTAX

### ByIdentity
```
Set-SnipeDepreciation [-NewName <String>] [-Months <Int32>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>
 [-ShowResponse] [<CommonParameters>]
```

### ByName
```
Set-SnipeDepreciation [-NewName <String>] [-Months <Int32>] -Name <String> [-ShowResponse] [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeDepreciation [-NewName <String>] [-Months <Int32>] -Id <Int32> [-ShowResponse] [<CommonParameters>]
```

## DESCRIPTION
The Set-Depreciation cmdlet changes the properties of an existing Snipe-IT depreciation object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-Depreciation -Name "General Potato Peeler" -NewName "Generic Potato Peeler"
```

Changes the name of depreciation "General Potato Peeler" to "Generic Potato Peeler".

## PARAMETERS

### -Id
The id of the item to update.

```yaml
Type: Int32
Parameter Sets: ByInternalId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
The identity of the item to update.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Months
The new duration of the depreciation in months.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the item to update.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewName
The new name of the depreciation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowResponse
If present, write the response from the Api to the pipeline.

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

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Depreciation, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.Depreciation

## NOTES

## RELATED LINKS
