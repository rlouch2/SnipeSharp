---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# CheckOut-SnipeAccessory

## SYNOPSIS
Checks out a Snipe IT accessory to a user.

## SYNTAX

```
CheckOut-SnipeAccessory
 [-Accessory] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Accessory]>
 -AssignedUser <UserBinding> [-Note <String>] [<CommonParameters>]
```

## DESCRIPTION
The CheckOut-Accessory cmdlet checks out an accessory to a user.

## EXAMPLES

### Example 1
```powershell
PS C:\> CheckOut-Accessory -Accessory 2 -AssignedUser "Marty McFly"
```

Checks out the accessory 2 to Marty McFly.

## PARAMETERS

### -Accessory
An Accessory identity.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Accessory]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -AssignedUser
The identity of a User to assign the Accessory to.

```yaml
Type: UserBinding
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Note
The note for the Accessory's log.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Accessory, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

### SnipeSharp.PowerShell.BindingTypes.UserBinding

### System.String

## OUTPUTS

### SnipeSharp.Models.RequestResponse`1[[SnipeSharp.Models.Asset, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
