---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeDepreciation

## SYNOPSIS
Creates a new Snipe-IT depreciation.

## SYNTAX

```
New-SnipeDepreciation [-Name] <String> [-Months] <Int32> [<CommonParameters>]
```

## DESCRIPTION
The New-Depreciation cmdlet creates a new depreciation object.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-Depreciation -Name "General Potato Peeler" -Months 36
```

Create a new depreciation named "General Potato Peeler" with all required properties set.

## PARAMETERS

### -Months
How long the depreciation lasts in months.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the depreciation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Int32

## OUTPUTS

### SnipeSharp.Models.Depreciation

## NOTES

## RELATED LINKS
