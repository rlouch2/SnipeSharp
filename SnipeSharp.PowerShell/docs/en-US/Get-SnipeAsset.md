---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeAsset

## SYNOPSIS
Gets a Snipe IT asset.

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
The Get-Asset cmdlet gets one or more asset objects.

The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-Asset Asset4638
```

Retrieve an asset by its Identity.

### Example 2
```powershell
PS C:\> Get-Asset -Name Asset4368
```

Retrieve an asset explicitly by its Name.

### Example 3
```powershell
1..100 | Get-Asset
```

Retrieve the first 100 assets by their identities.

## PARAMETERS

### -AssetTag
The asset tag for the Asset.

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
An identity for an object.

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
The internal Id of the Object.

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
Parameter Sets: All
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Serial
The serial Id for the Asset.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32[]

### System.String[]

### SnipeSharp.PowerShell.BindingTypes.AssetBinding[]

## OUTPUTS

### SnipeSharp.Models.Asset

## NOTES

## RELATED LINKS

[Find-SnipeAsset](Find-SnipeAsset.md)
