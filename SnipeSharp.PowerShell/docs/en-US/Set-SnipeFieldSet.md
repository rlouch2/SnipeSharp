---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeFieldSet

## SYNOPSIS
Changes the properties of an existing Snipe-IT field set.

## SYNTAX

### ByIdentity
```
Set-SnipeFieldSet [-NewName <String>] [-Add <ObjectBinding`1[]>] [-AddRequired <ObjectBinding`1[]>]
 [-Remove <ObjectBinding`1[]>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]> [-PassThru]
 [-Overwrite] [<CommonParameters>]
```

### ByName
```
Set-SnipeFieldSet [-NewName <String>] [-Add <ObjectBinding`1[]>] [-AddRequired <ObjectBinding`1[]>]
 [-Remove <ObjectBinding`1[]>] -Name <String> [-PassThru] [-Overwrite] [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeFieldSet [-NewName <String>] [-Add <ObjectBinding`1[]>] [-AddRequired <ObjectBinding`1[]>]
 [-Remove <ObjectBinding`1[]>] -Id <Int32> [-PassThru] [-Overwrite] [<CommonParameters>]
```

## DESCRIPTION
The Set-FieldSet cmdlet changes the properties of an existing Snipe-IT field set object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-FieldSet -Name "Peeler" -NewName "Potato Peeler"
```

Changes the name of fieldset "Peeler" to "Potato Peeler" to distinguish it from "Carrot Peeler".

## PARAMETERS

### -Add
A list of fields to associate with this fieldset.

```yaml
Type: ObjectBinding`1[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddRequired
A list of fields to associate with this fieldset, marked required.

```yaml
Type: ObjectBinding`1[]
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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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
The new name for the field set.

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

### -Remove
A list of fields to disassociate with this fieldset.

```yaml
Type: ObjectBinding`1[]
Parameter Sets: (All)
Aliases:

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

### -PassThru
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.FieldSet, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.FieldSet

## NOTES

## RELATED LINKS
