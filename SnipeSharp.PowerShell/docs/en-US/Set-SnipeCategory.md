---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeCategory

## SYNOPSIS
Changes the properties of an existing Snipe-IT category.

## SYNTAX

### ByIdentity
```
Set-SnipeCategory [-NewName <String>] [-Type <CategoryType>] [-EmailUserOnCheckInOrOut <Boolean>]
 [-IsAcceptanceRequired <Boolean>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]> [-ShowResponse]
 [<CommonParameters>]
```

### ByName
```
Set-SnipeCategory [-NewName <String>] [-Type <CategoryType>] [-EmailUserOnCheckInOrOut <Boolean>]
 [-IsAcceptanceRequired <Boolean>] -Name <String> [-ShowResponse] [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeCategory [-NewName <String>] [-Type <CategoryType>] [-EmailUserOnCheckInOrOut <Boolean>]
 [-IsAcceptanceRequired <Boolean>] -Id <Int32> [-ShowResponse] [<CommonParameters>]
```

## DESCRIPTION
The Set-Category cmdlet changes the properties of an existing Snipe-IT category object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-Category -Name 'Utility' -IsAcceptanceRequired $true
```

Changes the category 'Utility' to require EULA acceptance.

## PARAMETERS

### -EmailUserOnCheckInOrOut
Should users be emailed when they check in/out things from this category?

```yaml
Type: Boolean
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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Category]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsAcceptanceRequired
Is it required to accept the EULA?

```yaml
Type: Boolean
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
The new name of the category.

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

### -Type
The updated type the category is for.

```yaml
Type: CategoryType
Parameter Sets: (All)
Aliases:
Accepted values: Accessory, Asset, Consumable, Component, License

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Category, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.Category

## NOTES

## RELATED LINKS
