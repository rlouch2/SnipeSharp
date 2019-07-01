---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeCompany

## SYNOPSIS
Creates a new Snipe-IT company.

## SYNTAX

```
New-SnipeCompany [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
The New-Company cmdlet creates a new company object.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-Company -Name "Potato Inc."
```

Create a new company named "Potato Inc.".

## PARAMETERS

### -Name
The name of the company.

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

### SnipeSharp.Models.Company

## NOTES

## RELATED LINKS
