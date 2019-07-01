---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeStatusLabel

## SYNOPSIS
Creates a new Snipe-IT status label.

## SYNTAX

```
New-SnipeStatusLabel [-Name] <String> [-Type] <StatusType> [-Notes <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-StatusLabel cmdlet creates a new status label object.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-StatusLabel -Name "Assignable" -Type Deployable
```

Create a new deployable status label named "Assignable".

## PARAMETERS

### -Name
The name of the status label.

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

### -Notes
Any notes for the label.

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

### -Type
The type of status this label represents.

```yaml
Type: StatusType
Parameter Sets: (All)
Aliases:
Accepted values: Pending, Archived, Undeployable, Deployable, Deployed

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### SnipeSharp.Models.Enumerations.StatusType

## OUTPUTS

### SnipeSharp.Models.StatusLabel

## NOTES

## RELATED LINKS
