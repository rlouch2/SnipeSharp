---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# CheckOut-SnipeAsset

## SYNOPSIS
Checks out a Snipe IT asset to a user, location, or other asset.

## SYNTAX

### ToUser (Default)
```
CheckOut-SnipeAsset [-Asset] <AssetBinding> -AssignedUser <UserBinding> [-CheckOutAt <DateTime>]
 [-ExpectedCheckIn <DateTime>] [-Note <String>] [-AssetName <String>] [<CommonParameters>]
```

### ToLocation
```
CheckOut-SnipeAsset [-Asset] <AssetBinding>
 -AssignedLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>
 [-CheckOutAt <DateTime>] [-ExpectedCheckIn <DateTime>] [-Note <String>] [-AssetName <String>]
 [<CommonParameters>]
```

### ToAsset
```
CheckOut-SnipeAsset [-Asset] <AssetBinding> -AssignedAsset <AssetBinding> [-CheckOutAt <DateTime>]
 [-ExpectedCheckIn <DateTime>] [-Note <String>] [-AssetName <String>] [<CommonParameters>]
```

## DESCRIPTION
The CheckOut-Asset cmdlet checks out an asset to a user, location, or another asset.

## EXAMPLES

### Example 1
```powershell
PS C:\> CheckOut-Asset -Asset Asset1234 -AssignedUser "Marty McFly"
```

Checks out the asset Asset1234 to Marty McFly.

### Example 2
```powershell
PS C:\> CheckOut-Asset -Asset Asset1234 -AssignedLocation Chicago
```

Checks out the asset Asset1234 to the location Chicago.

### Example 3
```powershell
PS C:\> CheckOut-Asset -Asset Asset1234 -AssignedAsset Asset5678
```

Checks out the asset Asset1234 to the asset Asset5678.

## PARAMETERS

### -Asset
An Asset identity.

```yaml
Type: AssetBinding
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -AssetName
The asset's new name. Defaults to the asset's current name.

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

### -AssignedAsset
The identity of an Asset to assign the Asset to.

```yaml
Type: AssetBinding
Parameter Sets: ToAsset
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AssignedLocation
The identity of a Location to assign the Asset to.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]
Parameter Sets: ToLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AssignedUser
The identity of a User to assign the Asset to.

```yaml
Type: UserBinding
Parameter Sets: ToUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CheckOutAt
The date to mark this Asset as being checked out.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpectedCheckIn
The date to this Asset is expected to be checked back in.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Note
The note for the Asset's log.

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

### SnipeSharp.PowerShell.BindingTypes.AssetBinding

### SnipeSharp.PowerShell.BindingTypes.UserBinding

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Location, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

### System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]

### System.String

## OUTPUTS

### SnipeSharp.Models.RequestResponse`1[[SnipeSharp.Models.Asset, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[CheckIn-SnipeAsset](CheckIn-SnipeAsset.md)

[Get-Asset](Get-Asset.md)
