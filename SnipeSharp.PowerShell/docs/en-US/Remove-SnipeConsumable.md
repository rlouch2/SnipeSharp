---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Remove-SnipeConsumable

## SYNOPSIS
Removes a Snipe IT Consumable.

## SYNTAX

### ByName (Default)
```
Remove-SnipeConsumable -Name <String[]> [-ShowResponse] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInternalId
```
Remove-SnipeConsumable -InternalId <Int32[]> [-ShowResponse] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByIdentity
```
Remove-SnipeConsumable [-Identity] <ObjectBinding`1[]> [-ShowResponse] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-Consumable cmdlet removes one or more Consumable objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-Consumable 12
```

Removes a Consumable by its Internal Id.

### Example 2
```powershell
PS C:\> Remove-Consumable Consumable4368
```

Removes a Consumable explicitly by its Name.

### Example 3
```powershell
PS C:\> 1..100 | Remove-Consumable
```

Removes the first 100 Consumable objects by their Snipe IT internal Id numbers.

## PARAMETERS

### -Identity
An identity for an object.

```yaml
Type: ObjectBinding`1[]
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

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Consumable, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]][]

## OUTPUTS

### SnipeSharp.Models.RequestResponse`1[[SnipeSharp.Models.Consumable, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[Find-SnipeConsumable](Find-SnipeConsumable.md)