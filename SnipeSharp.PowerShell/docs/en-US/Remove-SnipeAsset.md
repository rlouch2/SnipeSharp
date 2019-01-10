---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Remove-SnipeAsset

## SYNOPSIS
Removes a Snipe IT asset.

## SYNTAX

### ByAssetTag (Default)
```
Remove-SnipeAsset -AssetTag <String[]> [-ShowResponse] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BySerial
```
Remove-SnipeAsset -Serial <String[]> [-ShowResponse] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInternalId
```
Remove-SnipeAsset -InternalId <Int32[]> [-ShowResponse] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByName
```
Remove-SnipeAsset -Name <String[]> [-ShowResponse] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByIdentity
```
Remove-SnipeAsset [-Identity] <AssetBinding[]> [-ShowResponse] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Remove-Asset cmdlet removes one or more asset objects from the Snipe IT database.

The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-Asset -InternalId 12
```

Removes an accessory by its Internal Id.

### Example 2
```powershell
PS C:\> Remove-Asset Asset4368
```

Removes an asset by its Name.

### Example 3
```powershell
PS C:\> 1..100 | Get-Asset | Remove-Asset
```

Removes the first 100 assets by their Snipe IT internal Id numbers.

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
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

### SnipeSharp.Models.RequestResponse`1[[SnipeSharp.Models.Asset, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[Get-SnipeAsset](Get-SnipeAsset.md)
