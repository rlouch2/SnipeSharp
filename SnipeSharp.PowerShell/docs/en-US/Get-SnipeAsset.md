---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeAsset

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### All (Default)
```
Get-SnipeAsset [-NoEnumerate] [<CommonParameters>]
```

### ByAssetTag
```
Get-SnipeAsset -AssetTag <String[]> [<CommonParameters>]
```

### BySerial
```
Get-SnipeAsset -Serial <String[]> [<CommonParameters>]
```

### ByInternalId
```
Get-SnipeAsset [-InternalId] <Int32[]> [<CommonParameters>]
```

### ByName
```
Get-SnipeAsset -Name <String[]> [<CommonParameters>]
```

### ByIdentity
```
Get-SnipeAsset [-Identity] <AssetBinding[]> [<CommonParameters>]
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

### -AssetTag
{{Fill AssetTag Description}}

```yaml
Type: String[]
Parameter Sets: ByAssetTag
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
{{Fill Identity Description}}

```yaml
Type: AssetBinding[]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -InternalId
{{Fill InternalId Description}}

```yaml
Type: Int32[]
Parameter Sets: ByInternalId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

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
{{Fill NoEnumerate Description}}

```yaml
Type: SwitchParameter
Parameter Sets: All
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Serial
{{Fill Serial Description}}

```yaml
Type: String[]
Parameter Sets: BySerial
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32[]

### System.String[]

### SnipeSharp.PowerShell.BindingTypes.AssetBinding[]

## OUTPUTS

### SnipeSharp.Models.Asset

## NOTES

## RELATED LINKS
