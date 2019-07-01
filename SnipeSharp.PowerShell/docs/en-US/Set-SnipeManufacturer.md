---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeManufacturer

## SYNOPSIS
Changes the properties of an existing Snipe-IT manufacturer.

## SYNTAX

### ByIdentity
```
Set-SnipeManufacturer [-NewName <String>] [-Url <Uri>] [-ImageUri <Uri>] [-SupportUrl <Uri>]
 [-SupportPhoneNumber <String>] [-SupportEmailAddress <String>]
 [-Identity] <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]>
 [-ShowResponse] [<CommonParameters>]
```

### ByName
```
Set-SnipeManufacturer [-NewName <String>] [-Url <Uri>] [-ImageUri <Uri>] [-SupportUrl <Uri>]
 [-SupportPhoneNumber <String>] [-SupportEmailAddress <String>] -Name <String> [-ShowResponse]
 [<CommonParameters>]
```

### ByInternalId
```
Set-SnipeManufacturer [-NewName <String>] [-Url <Uri>] [-ImageUri <Uri>] [-SupportUrl <Uri>]
 [-SupportPhoneNumber <String>] [-SupportEmailAddress <String>] -Id <Int32> [-ShowResponse]
 [<CommonParameters>]
```

## DESCRIPTION
The Set-Manufacturer cmdlet changes the properties of an existing Snipe-IT manufacturer object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-Manufacturer -Name "Potato Peelers Inc." -SupportPhoneNumber '+1 (555) 555-5555'
```

Changes the support phone number for manufacturer "Potato Peelers Inc." to "+1 (555) 555-5555".

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
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Manufacturer]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ImageUri
The updated uri of the image for the manufacturer.

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
The new name for the manufacturer.

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

### -SupportEmailAddress
The updated email address to contact the manufacturer by for support.

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

### -SupportPhoneNumber
The updated phone number for the manufacturer's support line.

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

### -SupportUrl
The updated url for the manufacturer's support portal.

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

### -Url
The updated url for the manufacturer's website.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.Manufacturer, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### SnipeSharp.Models.Manufacturer

## NOTES

## RELATED LINKS
