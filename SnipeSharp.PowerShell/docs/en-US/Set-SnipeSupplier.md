---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Set-SnipeSupplier

## SYNOPSIS
Changes the properties of an existing Snipe-IT supplier.

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
The Set-Supplier cmdlet changes the properties of an existing Snipe-IT supplier object.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-Supplier -Name "Potato Warehouse &amp; Wholesale" -PhoneNumber '+1 (555) 555-5555'
```

Changes the contact phone number for supplier "Potato Warehouse &amp; Wholesale" to "+1 (555) 555-5555".

## PARAMETERS

### -Address
The supplier's updated address line.

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
The supplier's updated second address line.

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
The supplier's updated address city.

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
The updated name of the supplier contact.

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
The supplier's updated address country.

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
The supplier contact's updated email address.

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
The supplier contact's updated fax number.

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
The updated uri of the image for the supplier.

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
The new name of the supplier.

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
Any notes about the supplier.

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
The supplier contact's updated phone number.

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
The supplier's updated address state.

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
The supplier's updated address zip code.

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
