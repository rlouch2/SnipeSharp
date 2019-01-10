---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeCustomField

## SYNOPSIS
Gets a Snipe IT custom field.

## SYNTAX

### All (Default)
```
Get-SnipeCustomField [-NoEnumerate] [<CommonParameters>]
```

### ByInternalId
```
Get-SnipeCustomField [-InternalId] <Int32[]> [<CommonParameters>]
```

### ByName
```
Get-SnipeCustomField -Name <String[]> [<CommonParameters>]
```

### ByIdentity
```
Get-SnipeCustomField [-Identity] <ObjectBinding`1[]> [<CommonParameters>]
```

## DESCRIPTION
The Get-CustomField cmdlet gets one or more custom field objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-CustomField 2
```

Retrieve an fieldset by its Internal Id.

### Example 2
```powershell
PS C:\> Get-CustomField Length
```

Retrieve a custom field explicitly by its Name.

### Example 3
```powershell
PS C:\> 1..100 | Get-CustomField
```

Retrieve the first 100 custom fields by their Snipe IT internal Id numbers.

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
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -NoEnumerate
If present, return the result as a ResponseCollection rather than enumerating.

```yaml
Type: SwitchParameter
Parameter Sets: All
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

### System.Int32[]

### System.String[]

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.CustomField, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]][]

## OUTPUTS

### SnipeSharp.Models.CustomField

## NOTES

## RELATED LINKS

[Find-SnipeCustomField](Find-SnipeCustomField.md)
