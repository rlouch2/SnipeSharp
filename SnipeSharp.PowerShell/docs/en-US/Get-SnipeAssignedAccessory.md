---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeAssignedAccessory

## SYNOPSIS
Gets the Snipe IT accessories checked out by a user.

## SYNTAX

```
Get-SnipeAssignedAccessory [-User] <UserBinding[]> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-AssignedAccessory cmdlet gets, for each user provided, the accessory objects associated with that user.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AssignedAccessory User1234
```

Retrieves the accessories checked out by the user User1234.

### Example 2
```powershell
PS C:\> Get-AssignedAccessory User1234, User5678
```

Retrieve the accessories checked out by the user User1234 or the user User5678.

## PARAMETERS

### -NoEnumerate
If present, return the result as a ResponseCollection rather than enumerating.

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

### -User
The user to find the accessories of.

```yaml
Type: UserBinding[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.UserBinding[]

## OUTPUTS

### SnipeSharp.Models.Asset

## NOTES

## RELATED LINKS
