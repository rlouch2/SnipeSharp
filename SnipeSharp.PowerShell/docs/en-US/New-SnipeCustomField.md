---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeCustomField

## SYNOPSIS
Creates a new Snipe-IT custom field.

## SYNTAX

```
New-SnipeCustomField [-Name] <String> [-Type <CustomFieldElement>] [-Format <String>] [-FieldValue <String[]>]
 [-IsFieldEncrypted <Boolean>] [-ShowInCheckOutEmail <Boolean>] [-HelpText <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-CustomField cmdlet creates a new custom field object, but does not associate it with any field sets.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-CustomField -Name "Length"
```

Create a new custom field named "Length".

## PARAMETERS

### -FieldValue
The values of this field.

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
The format of the field, for example:

| Format     | Description                           |
|------------|---------------------------------------|
| alpha      | Only alphabetical characters.         |
| alpha_dash | Only alphabetical characters and '-'. |
| numeric    | Only numbers.                         |
| alpha_num  | Only alphanumeric characters.         |
| email      | A string in an email format.          |
| date       | A date.                               |
| url        | A url.                                |
| ip         | Any IP address.                       |
| ipv4       | Explicitly an IPv4 address.           |
| ipv6       | Explicitly an IPv6 address.           |
| boolean    | A boolean value.                      |

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
The help text for the field in the UI.

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

### -IsFieldEncrypted
Is the field encrypted?

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
The name of the field set.

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

### -ShowInCheckOutEmail
Should the field be listed in emails sent to users?

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
The type of the field.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### SnipeSharp.Models.Enumerations.CustomFieldElement

### System.String[]

### System.Boolean

## OUTPUTS

### SnipeSharp.Models.CustomField

## NOTES

## RELATED LINKS
