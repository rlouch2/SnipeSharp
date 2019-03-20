---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeLicenseSeat

## SYNOPSIS
Gets the License Seats of a Snipe IT License.

## SYNTAX

```
Get-SnipeLicenseSeat [-License] <ObjectBinding`1[]> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-LicenseSeat cmdlet gets, for each license provided, the license seat objects associated with that license.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-LicenseSeat License12
```

Retrieves the license seats for the license License12.

### Example 2
```powershell
PS C:\> Get-LicenseSeat License12, License11
```

Retrieves the license seats for the licenses License12 and License11.

## PARAMETERS

### -License
The license to retrieve the seats of.

```yaml
Type: ObjectBinding`1[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[[SnipeSharp.Models.License, SnipeSharp, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]][]

## OUTPUTS

### SnipeSharp.Models.LicenseSeat

## NOTES

## RELATED LINKS
