---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeFieldSetOrder

## SYNOPSIS
Changes the order of fields in an existing Snipe-IT field set.

## SYNTAX

### ByIdentity
```
Set-SnipeFieldSetOrder -Order <ObjectBinding`1[]>
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.FieldSet]> [-ShowResponse]
 [<CommonParameters>]
```

### ByName
```
Set-SnipeFieldSetOrder -Order <ObjectBinding`1[]> -Name <String> [-ShowResponse] [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeFieldSetOrder -Order <ObjectBinding`1[]> -Id <Int32> [-ShowResponse] [<CommonParameters>]
```

## DESCRIPTION
The Set-FieldSetOrder cmdlet changes the order of custom fields in an existing Snipe-IT field set object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-FieldSetOrder -Name "Potato Peeler" -Order "Length", "Width", "Handle Size"
```

Changes the order of fields in the fieldset "Potato Peeler" to  "Length, Width, Handle Size".

## PARAMETERS

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

### -Order
The fields of the field set, in the order desired.

```yaml
Type: ObjectBinding`1[]
Parameter Sets: (All)
Aliases: Fields

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.FieldSet, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.FieldSet

## NOTES

## RELATED LINKS
