---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeFieldSetOrder

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity
```
Set-SnipeFieldSetOrder -Order <ObjectBinding`1[]>
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]>
 [<CommonParameters>]
```

### ByName
```
Set-SnipeFieldSetOrder -Order <ObjectBinding`1[]> -Name <String> [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeFieldSetOrder -Order <ObjectBinding`1[]> -Id <Int32> [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -Order
{{Fill Order Description}}

```yaml
Type: ObjectBinding`1[]
Parameter Sets: (All)
Aliases: Fields

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.FieldSet, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.FieldSet

## NOTES

## RELATED LINKS
