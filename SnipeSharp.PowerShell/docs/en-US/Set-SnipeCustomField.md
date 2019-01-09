---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeCustomField

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIdentity
```
Set-SnipeCustomField [[-NewName] <String>] [-Type <CustomFieldElement>] [-Format <String>]
 [-FieldValue <String[]>] [-IsFieldEncrypted <Boolean>] [-ShowInCheckOutEmail <Boolean>] [-HelpText <String>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.CustomField]>
 [<CommonParameters>]
```

### ByName
```
Set-SnipeCustomField [[-NewName] <String>] [-Type <CustomFieldElement>] [-Format <String>]
 [-FieldValue <String[]>] [-IsFieldEncrypted <Boolean>] [-ShowInCheckOutEmail <Boolean>] [-HelpText <String>]
 -Name <String> [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeCustomField [[-NewName] <String>] [-Type <CustomFieldElement>] [-Format <String>]
 [-FieldValue <String[]>] [-IsFieldEncrypted <Boolean>] [-ShowInCheckOutEmail <Boolean>] [-HelpText <String>]
 -Id <Int32> [<CommonParameters>]
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

### -FieldValue
{{Fill FieldValue Description}}

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Format
{{Fill Format Description}}

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

### -HelpText
{{Fill HelpText Description}}

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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.CustomField]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsFieldEncrypted
{{Fill IsFieldEncrypted Description}}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ShowInCheckOutEmail
{{Fill ShowInCheckOutEmail Description}}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Type
{{Fill Type Description}}

```yaml
Type: CustomFieldElement
Parameter Sets: (All)
Aliases:
Accepted values: List, Text, TextArea

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### SnipeSharp.Models.Enumerations.CustomFieldElement

### System.String[]

### System.Boolean

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.CustomField, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.CustomField

## NOTES

## RELATED LINKS
