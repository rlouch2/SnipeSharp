---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeStatusLabel

## SYNOPSIS
Changes the properties of an existing Snipe-IT status label.

## SYNTAX

### ByIdentity
```
Set-SnipeStatusLabel [-NewName <String>] [-Type <StatusType>] [-Notes <String>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>
 [-ShowResponse] [<CommonParameters>]
```

### ByName
```
Set-SnipeStatusLabel [-NewName <String>] [-Type <StatusType>] [-Notes <String>] -Name <String> [-ShowResponse]
 [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeStatusLabel [-NewName <String>] [-Type <StatusType>] [-Notes <String>] -Id <Int32> [-ShowResponse]
 [<CommonParameters>]
```

## DESCRIPTION
The Set-StatusLabel cmdlet changes the properties of an existing Snipe-IT status label object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-StatusLabel -Name "Assignable" -Type "Deployable"
```

Changes the status label "Assignable" to be a label for deployable objects.

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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]
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
The new name of the status label.

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

### -Notes
Any notes about the status label.

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
The updated type of status the label represents.

```yaml
Type: StatusType
Parameter Sets: (All)
Aliases:
Accepted values: Pending, Archived, Undeployable, Deployable, Deployed

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.StatusLabel, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.StatusLabel

## NOTES

## RELATED LINKS
