---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeAsset

## SYNOPSIS
Changes the properties of an existing Snipe-IT asset.

## SYNTAX

### ByIdentity (Default)
```
Set-SnipeAsset [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>]
 [-Identity] <AssetBinding> [-ShowResponse] [-Overwrite] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByAssetTag
```
Set-SnipeAsset -AssetTag <String> [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-ShowResponse]
 [-Overwrite] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BySerial
```
Set-SnipeAsset -Serial <String> [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-ShowResponse]
 [-Overwrite] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByName
```
Set-SnipeAsset [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] -Name <String>
 [-ShowResponse] [-Overwrite] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeAsset [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] -Id <Int32>
 [-ShowResponse] [-Overwrite] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Set-Asset cmdlet changes the properties of an existing Snipe-IT asset object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-Asset -AssetTag '06514' -Status 'Retired'
```

Changes the status of the asset with the asset tag "06541" to "Retired".

## PARAMETERS

### -AssetTag
The asset tag of the asset to update.

```yaml
Type: String
Parameter Sets: ByAssetTag
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Company
The updated owner company of the asset.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]
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

### -CustomFields
Custom fields used by the asset's model's field set.

```yaml
Type: System.Collections.Generic.Dictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultLocation
The updated default location the asset will return to when unassigned.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The id of the asset to update.

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
The identity of the asset to update.

```yaml
Type: AssetBinding
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ImageUri
The updated uri of the image for the asset.

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

### -Location
The updated location of the asset.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Model
The updated model of the asset.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the asset to update.

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

### -NewAssetTag
The updated asset tag of the asset.

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

### -NewName
The updated name of the asset.

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

### -NewSerial
The updated serial number of the asset.

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
Any notes for the asset.

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

### -OrderNumber
The updated order number for the asset's purchase.

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

### -PurchaseCost
The updated purchase cost for the asset.

```yaml
Type: Decimal
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PurchaseDate
The updated purchase date for the asset.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Serial
The serial number of the asset to update.

```yaml
Type: String
Parameter Sets: BySerial
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Status
The updated status label of the asset.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Supplier
The updated supplier for the asset.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WarrantyMonths
The updated warranty period for the asset in months.

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

### -Overwrite
If present, completely overwrite all properties the remote object with the current or provided values.

The provided object will be fetched, its values updated with the ones provided to the cmdlet, then all values given to the API.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.AssetBinding

### System.String

### System.Int32

## OUTPUTS

### SnipeSharp.Models.Asset

## NOTES

## RELATED LINKS
