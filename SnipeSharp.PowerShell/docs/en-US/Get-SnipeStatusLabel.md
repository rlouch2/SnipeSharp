---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeStatusLabel

## SYNOPSIS
Gets a Snipe IT status label.

## SYNTAX

### All (Default)
```
Get-SnipeStatusLabel [<CommonParameters>]
```

### ByInternalId
```
Get-SnipeStatusLabel -InternalId <Int32[]> [<CommonParameters>]
```

### ByName
```
Get-SnipeStatusLabel -Name <String[]> [<CommonParameters>]
```

### ByIdentity
```
Get-SnipeStatusLabel [-Identity] <ObjectBinding`1[]> [<CommonParameters>]
```

## DESCRIPTION
The Get-StatusLabel cmdlet gets one or more status label objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-StatusLabel 14
```

Retrieve an status label by its Internal Id.

### Example 2
```powershell
PS C:\> Get-StatusLabel StatusLabel4368
```

Retrieve an status label explicitly by its Name.

### Example 3
```powershell
1..100 | Get-StatusLabel
```

Retrieve the first 100 status labels by their Snipe IT internal Id numbers.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32[]

### System.String[]

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.StatusLabel, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]][]

## OUTPUTS

### SnipeSharp.Models.StatusLabel

## NOTES

## RELATED LINKS

[Find-SnipeStatusLabel](Find-SnipeStatusLabel.md)
