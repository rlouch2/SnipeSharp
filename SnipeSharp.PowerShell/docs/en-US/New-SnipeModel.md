---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeModel

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

```
New-SnipeModel [-Name] <String>
 -Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>
 [-ImageUri <Uri>] [-ModelNumber <String>]
 [-Depreciation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Depreciation]>]
 -Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>
 [-FieldSet <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]>]
 [-EndOfLife <Int32>] [-Notes <String>] [<CommonParameters>]
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

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Manufacturer
{{Fill Manufacturer Description}}

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

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

### -Notes
{{Fill Notes Description}}

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Manufacturer, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

### System.Uri

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Depreciation, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Category, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.FieldSet, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

### System.Int32

## OUTPUTS

### SnipeSharp.Models.Model

## NOTES

## RELATED LINKS
