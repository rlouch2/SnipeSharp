---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeLocation

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity
```
Set-SnipeLocation [-NewName <String>] [-ImageUri <Uri>] [-Address <String>] [-Address2 <String>]
 [-City <String>] [-State <String>] [-Country <String>] [-ZipCode <String>] [-Currency <String>]
 [-ParentLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Manager <UserBinding>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>
 [<CommonParameters>]
```

### ByName
```
Set-SnipeLocation [-NewName <String>] [-ImageUri <Uri>] [-Address <String>] [-Address2 <String>]
 [-City <String>] [-State <String>] [-Country <String>] [-ZipCode <String>] [-Currency <String>]
 [-ParentLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Manager <UserBinding>] -Name <String> [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeLocation [-NewName <String>] [-ImageUri <Uri>] [-Address <String>] [-Address2 <String>]
 [-City <String>] [-State <String>] [-Country <String>] [-ZipCode <String>] [-Currency <String>]
 [-ParentLocation <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Manager <UserBinding>] -Id <Int32> [<CommonParameters>]
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

### -Address
{{Fill Address Description}}

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

### -Address2
{{Fill Address2 Description}}

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

### -City
{{Fill City Description}}

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

### -Country
{{Fill Country Description}}

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

### -Currency
{{Fill Currency Description}}

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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ImageUri
{{Fill ImageUri Description}}

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manager
{{Fill Manager Description}}

```yaml
Type: UserBinding
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -ParentLocation
{{Fill ParentLocation Description}}

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
{{Fill State Description}}

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

### -ZipCode
{{Fill ZipCode Description}}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Location, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.Location

## NOTES

## RELATED LINKS
