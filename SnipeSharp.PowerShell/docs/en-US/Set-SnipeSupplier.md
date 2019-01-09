---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeSupplier

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity
```
Set-SnipeSupplier [[-NewName] <String>] [-ImageUri <Uri>] [-Address <String>] [-Address2 <String>]
 [-City <String>] [-State <String>] [-Country <String>] [-ZipCode <String>] [-FaxNumber <String>]
 [-PhoneNumber <String>] [-EmailAddress <String>] [-Contact <String>] [-Notes <String>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]>
 [<CommonParameters>]
```

### ByName
```
Set-SnipeSupplier [[-NewName] <String>] [-ImageUri <Uri>] [-Address <String>] [-Address2 <String>]
 [-City <String>] [-State <String>] [-Country <String>] [-ZipCode <String>] [-FaxNumber <String>]
 [-PhoneNumber <String>] [-EmailAddress <String>] [-Contact <String>] [-Notes <String>] -Name <String>
 [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeSupplier [[-NewName] <String>] [-ImageUri <Uri>] [-Address <String>] [-Address2 <String>]
 [-City <String>] [-State <String>] [-Country <String>] [-ZipCode <String>] [-FaxNumber <String>]
 [-PhoneNumber <String>] [-EmailAddress <String>] [-Contact <String>] [-Notes <String>] -Id <Int32>
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

### -Contact
{{Fill Contact Description}}

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

### -EmailAddress
{{Fill EmailAddress Description}}

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

### -FaxNumber
{{Fill FaxNumber Description}}

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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Supplier]
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
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -PhoneNumber
{{Fill PhoneNumber Description}}

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

### System.String

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Supplier, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.Supplier

## NOTES

## RELATED LINKS
