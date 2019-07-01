---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeFieldSet

## SYNOPSIS
Creates a new Snipe-IT field set.

## SYNTAX

```
New-SnipeFieldSet [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
The New-FieldSet cmdlet creates a new field set object.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-FieldSet -Name "Peeler"
```

Create a new field set named "Peeler".

## PARAMETERS

### -Name
The name of the field set.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### SnipeSharp.Models.FieldSet

## NOTES

## RELATED LINKS
