---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeModel

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity
```
Set-SnipeModel [-NewName <String>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-ImageUri <Uri>] [-ModelNumber <String>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-FieldSet <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]>]
 [-EndOfLife <Int32>] [-Notes <String>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]> [<CommonParameters>]
```

### ByName
```
Set-SnipeModel [-NewName <String>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-ImageUri <Uri>] [-ModelNumber <String>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-FieldSet <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]>]
 [-EndOfLife <Int32>] [-Notes <String>] -Name <String> [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeModel [-NewName <String>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-ImageUri <Uri>] [-ModelNumber <String>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-FieldSet <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]>]
 [-EndOfLife <Int32>] [-Notes <String>] -Id <Int32> [<CommonParameters>]
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

### -Category
{{Fill Category Description}}

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

### -Depreciation
{{Fill Depreciation Description}}

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndOfLife
{{Fill EndOfLife Description}}

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

### -FieldSet
{{Fill FieldSet Description}}

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ImageUri
{{Fill ImageUri Description}}

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manufacturer
{{Fill Manufacturer Description}}

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

### -ModelNumber
{{Fill ModelNumber Description}}

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
{{Fill NewName Description}}

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

### -Notes
{{Fill Notes Description}}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Model, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.Model

## NOTES

## RELATED LINKS
