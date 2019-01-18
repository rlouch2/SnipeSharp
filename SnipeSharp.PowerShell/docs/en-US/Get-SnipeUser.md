---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Get-SnipeUser

## SYNOPSIS
Gets a Snipe IT user.

## SYNTAX

### All (Default)
```
Get-SnipeUser [-Deleted <Boolean>] [-NoEnumerate] [<CommonParameters>]
```

### ByUserName
```
Get-SnipeUser -UserName <String[]> [-Deleted <Boolean>] [-NoEnumerate] [<CommonParameters>]
```

### ByEmailAddress
```
Get-SnipeUser -EmailAddress <String[]> [-Deleted <Boolean>] [-NoEnumerate] [<CommonParameters>]
```

### ByIdentity
```
Get-SnipeUser [-Deleted <Boolean>] [-Identity] <UserBinding[]> [-NoEnumerate] [<CommonParameters>]
```

### ByName
```
Get-SnipeUser [-Deleted <Boolean>] -Name <String[]> [-NoEnumerate] [<CommonParameters>]
```

### Me
```
Get-SnipeUser [-Me] [-NoEnumerate] [<CommonParameters>]
```

### ByInternalId
```
Get-SnipeUser [-InternalId] <Int32[]> [-NoEnumerate] [<CommonParameters>]
```

## DESCRIPTION
The Get-User cmdlet gets one or more user objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-User 14
```

Retrieve an user by its Internal Id.

### Example 2
```powershell
PS C:\> Get-User -UserName User4368
```

Retrieve an user explicitly by its Name.

### Example 3
```powershell
PS C:\> 1..100 | Get-User
```

Retrieve the first 100 users by their Snipe IT internal Id numbers.

### Example 3

## PARAMETERS

### -EmailAddress
The email address for the User.

```yaml
Type: String[]
Parameter Sets: ByEmailAddress
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
An identity for an object.

```yaml
Type: UserBinding[]
Parameter Sets: ByIdentity
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -InternalId
The internal Id of the Object.

```yaml
Type: Int32[]
Parameter Sets: ByInternalId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Object.

```yaml
Type: String[]
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

### -UserName
The username for the User.

```yaml
Type: String[]
Parameter Sets: ByUserName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Deleted
Find deleted users, or non-deleted users?

```yaml
Type: Boolean
Parameter Sets: All, ByUserName, ByEmailAddress, ByIdentity, ByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Me
Get the current user for the API.

```yaml
Type: SwitchParameter
Parameter Sets: Me
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32[]

### System.String[]

### SnipeSharp.PowerShell.BindingTypes.UserBinding[]

## OUTPUTS

### SnipeSharp.Models.User

## NOTES

## RELATED LINKS

[Find-User](Find-User.md)
