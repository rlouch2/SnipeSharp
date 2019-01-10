---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeAccessory

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity
```
Set-SnipeAccessory [-NewName <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [-ModelNumber <String>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Quantity <Int32>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-OrderNumber <String>]
 [-MinimumQuantity <Int32>] [-ImageUri <Uri>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Accessory]>
 [<CommonParameters>]
```

### ByName
```
Set-SnipeAccessory [-NewName <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [-ModelNumber <String>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Quantity <Int32>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-OrderNumber <String>]
 [-MinimumQuantity <Int32>] [-ImageUri <Uri>] -Name <String> [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeAccessory [-NewName <String>]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Manufacturer <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>]
 [-Supplier <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>]
 [-ModelNumber <String>]
 [-Category <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Quantity <Int32>] [-PurchaseDate <DateTime>] [-PurchaseCost <Decimal>] [-OrderNumber <String>]
 [-MinimumQuantity <Int32>] [-ImageUri <Uri>] -Id <Int32> [<CommonParameters>]
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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Accessory]
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

### -MinimumQuantity
{{Fill MinimumQuantity Description}}

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

### -Quantity
{{Fill Quantity Description}}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Accessory, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.Accessory

## NOTES

## RELATED LINKS
