---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeStatusLabel

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity
```
Set-SnipeStatusLabel [-NewName <String>] [-Type <StatusType>] [-Notes <String>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.StatusLabel]>
 [<CommonParameters>]
```

### ByName
```
Set-SnipeStatusLabel [-NewName <String>] [-Type <StatusType>] [-Notes <String>] -Name <String>
 [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeStatusLabel [-NewName <String>] [-Type <StatusType>] [-Notes <String>] -Id <Int32>
 [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Id
{{Fill Id Description}}

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
{{Fill Identity Description}}

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
{{Fill Name Description}}

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
{{Fill NewName Description}}

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
{{Fill Notes Description}}

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

### -Type
{{Fill Type Description}}

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.StatusLabel, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.StatusLabel

## NOTES

## RELATED LINKS
