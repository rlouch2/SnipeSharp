---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# New-SnipeManufacturer

## SYNOPSIS
Creates a new Snipe-IT manufacturer.

## SYNTAX

```
New-SnipeManufacturer [-Name] <String> [-Url <Uri>] [-ImageUri <Uri>] [-SupportUrl <Uri>]
 [-SupportPhoneNumber <String>] [-SupportEmailAddress <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-Manufacturer cmdlet creates a new manufacturer object.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-Manufacturer -Name "Potato Peelers Inc."
```

Create a new manufacturer named "Potato Peelers Inc." with all required properties set.

## PARAMETERS

### -ImageUri
The uri of the image for the manufacturer.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the manufacturer.

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

### -SupportEmailAddress
The email address to contact the manufacturer by for support.

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

### -SupportPhoneNumber
The phone number for the manufacturer's support line.

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

### -SupportUrl
The url for the manufacturer's support portal.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Url
The url of the manufacturer's website.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

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

### System.Uri

## OUTPUTS

### SnipeSharp.Models.Manufacturer

## NOTES

## RELATED LINKS
