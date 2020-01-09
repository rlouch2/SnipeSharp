---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# CheckIn-SnipeAccessory

## SYNOPSIS
Checks in a Snipe IT accessory.

## SYNTAX

```
CheckIn-SnipeAccessory
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Accessory]> [-Note <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The CheckIn-Accessory cmdlet checks in one or more accessory objects.

## EXAMPLES

### Example 1
```powershell
PS C:\> CheckIn-Accessory 6
```

Checks in the assigned accessory with ID 6.

## PARAMETERS

### -Identity
An Accessory identity.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Accessory]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Note
The note for the Accessory's log.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Accessory, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

### System.String

## OUTPUTS

### SnipeSharp.Models.RequestResponse`1[[SnipeSharp.Models.Asset, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
