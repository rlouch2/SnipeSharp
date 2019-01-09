---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeAsset

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity (Default)
```
Set-SnipeAsset [-Identity] <AssetBinding> [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-AssignedTo <CommonEndPointModel>] [-AssignedType <AssignedToType>]
 [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByName
```
Set-SnipeAsset -Name <String> [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-AssignedTo <CommonEndPointModel>] [-AssignedType <AssignedToType>]
 [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeAsset -Id <Int32> [-NewAssetTag <String>] [-NewName <String>] [-NewSerial <String>]
 [-Model <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Model]>]
 [-Status <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>] [-Notes <String>]
 [-OrderNumber <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-DefaultLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-ImageUri <Uri>] [-AssignedTo <CommonEndPointModel>] [-AssignedType <AssignedToType>]
 [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
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
 [-ImageUri <Uri>] [-AssignedTo <CommonEndPointModel>] [-AssignedType <AssignedToType>]
 [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
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
 [-ImageUri <Uri>] [-AssignedTo <CommonEndPointModel>] [-AssignedType <AssignedToType>]
 [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-WarrantyMonths <Int32>]
 [-CustomFields <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
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
Type: String
Parameter Sets: ByAssetTag
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AssignedTo
{{Fill AssignedTo Description}}

```yaml
Type: CommonEndPointModel
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedType
{{Fill AssignedType Description}}

```yaml
Type: AssignedToType
Parameter Sets: (All)
Aliases:
Accepted values: User, Location, Asset

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Company
{{Fill Company Description}}

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

### -CustomFields
{{Fill CustomFields Description}}

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
{{Fill DefaultLocation Description}}

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
{{Fill Id Description}}

```yaml
Type: Int32
Parameter Sets: ByInternalId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Identity
{{Fill Identity Description}}

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

### -Location
{{Fill Location Description}}

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
{{Fill Model Description}}

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
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NewAssetTag
{{Fill NewAssetTag Description}}

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

### -NewSerial
{{Fill NewSerial Description}}

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

### -OrderNumber
{{Fill OrderNumber Description}}

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
{{Fill PurchaseCost Description}}

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
{{Fill PurchaseDate Description}}

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
{{Fill Serial Description}}

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

### -Status
{{Fill Status Description}}

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
{{Fill Supplier Description}}

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
{{Fill WarrantyMonths Description}}

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

### SnipeSharp.PowerShell.BindingTypes.AssetBinding

### System.String

### System.Int32

## OUTPUTS

### SnipeSharp.Models.Asset

## NOTES

## RELATED LINKS
