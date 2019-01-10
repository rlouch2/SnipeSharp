---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Find-SnipeUser

## SYNOPSIS
Finds a Snipe IT user.

## SYNTAX

```
Find-SnipeUser [-IncludeDeleted]
 [-Company <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]>]
 [-Location <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Location]>]
 [-Group <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Group]>]
 [-Department <SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Department]>]
 [[-SearchString] <String>] [-SortOrder <SearchOrder>] [-SortColumn <UserSearchColumn>] [-NoEnumerate]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
The Find-User cmdlet finds user objects by filter, company, location, group, or department.

## EXAMPLES

### Example 1
```powershell
PS C:\> Find-User -IncludeDeleted
```

Finds all users, included deleted ones.

### Example 2
```powershell
PS C:\> Find-User "ThePotatoPeeler"
```

Finds users that match the search string "ThePotatoPeeler".

### Example 3
```powershell
PS C:\> Find-User -Company $x
```

Finds users that work for company `$x`.

## PARAMETERS

### -Company
Filter by company.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Company]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Department
Filter by department.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Department]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
Filter by group membership.

```yaml
Type: SnipeSharp.PowerShell.BindingTypes.ObjectBinding`1[SnipeSharp.Models.Group]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeDeleted
If present, also search for deleted users.

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

### -Location
Filter by location.

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

### -SearchString
The string to search for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SortColumn
On which column to sort the data.

```yaml
Type: UserSearchColumn
Parameter Sets: (All)
Aliases:
Accepted values: Manager, Location, Department, LastName, FirstName, EmailAddress, JobTitle, UserName, EmployeeNumber, IsActivated, CreatedAt, IsEnrolledInTwoFactor, IsOptedInToTwoFactor, LastLoginDate, AssetsCount, LicensesCount, ConsumablesCount, AccessoriesCount, PhoneNumber, Address, City, State, Country, ZipCode, Id

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SortOrder
Which way to sort the data.

```yaml
Type: SearchOrder
Parameter Sets: (All)
Aliases:
Accepted values: Ascending, Descending

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Reports the number of objects in the data set (an integer) followed by the objects.
If the cmdlet cannot determine the total count, it returns 'Unknown total count'.

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

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: UInt64
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

## OUTPUTS

### SnipeSharp.Models.User

## NOTES

## RELATED LINKS
