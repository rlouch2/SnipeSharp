---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeCustomField

## SYNOPSIS
Changes the properties of an existing Snipe-IT custom field.

## SYNTAX

### ByIdentity
```
Set-SnipeCustomField [[-NewName] <String>] [-Type <CustomFieldElement>] [-Format <String>]
 [-FieldValue <String[]>] [-IsFieldEncrypted <Boolean>] [-ShowInCheckOutEmail <Boolean>] [-HelpText <String>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.CustomField]>
 [-ShowResponse] [-Overwrite] [<CommonParameters>]
```

### ByName
```
Set-SnipeCustomField [[-NewName] <String>] [-Type <CustomFieldElement>] [-Format <String>]
 [-FieldValue <String[]>] [-IsFieldEncrypted <Boolean>] [-ShowInCheckOutEmail <Boolean>] [-HelpText <String>]
 -Name <String> [-ShowResponse] [-Overwrite] [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeCustomField [[-NewName] <String>] [-Type <CustomFieldElement>] [-Format <String>]
 [-FieldValue <String[]>] [-IsFieldEncrypted <Boolean>] [-ShowInCheckOutEmail <Boolean>] [-HelpText <String>]
 -Id <Int32> [-ShowResponse] [-Overwrite] [<CommonParameters>]
```

## DESCRIPTION
The Set-CustomField cmdlet changes the properties of an existing Snipe-IT custom field object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-CustomField -Name "Length" -Format "numeric"
```

Changes the format of field "Length" to "numeric".

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
The name of the field set.

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

### -Overwrite
If present, completely overwrite all properties the remote object with the current or provided values.

The provided object will be fetched, its values updated with the ones provided to the cmdlet, then all values given to the API.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

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
