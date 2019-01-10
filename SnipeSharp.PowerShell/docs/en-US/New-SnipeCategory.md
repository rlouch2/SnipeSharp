---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeCategory

## SYNOPSIS
Creates a new Snipe-IT category.

## SYNTAX

```
New-SnipeCategory [-Name] <String> [-Type] <CategoryType> [-EmailUserOnCheckInOrOut <Boolean>]
 [-IsAcceptanceRequired <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
The New-Category cmdlet creates a new category object.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-Category -Name "Utility" -Type Accessory
```

Create a new category for accessories named "Utility".

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
The name of the category.

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

### -Type
What type the category is for.

```yaml
Type: CategoryType
Parameter Sets: (All)
Aliases:
Accepted values: Accessory, Asset, Consumable, Component, License

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### SnipeSharp.Models.Enumerations.CategoryType

## OUTPUTS

### SnipeSharp.Models.Category

## NOTES

## RELATED LINKS
