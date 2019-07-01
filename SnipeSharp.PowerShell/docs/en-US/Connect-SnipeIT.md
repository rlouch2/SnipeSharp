---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Connect-SnipeIT

## SYNOPSIS
Connects to Snipe IT.

## SYNTAX

```
Connect-SnipeIT [-Token] <String> [-Uri] <Uri> [<CommonParameters>]
```

## DESCRIPTION
The Connect-SnipeIT cmdlet begins a session with a Snipe IT instance.

You may only have one SnipeIT session per PowerShell session.

## EXAMPLES

### Example 1
```powershell
PS C:\> Connect-SnipeIT -Uri 'https://inventory.example.com/api/v1' -ApiToken $ApiToken
```

Connect to a Snipe IT session at "inventory.example.com" with the token in $ApiToken.

## PARAMETERS

### -Token
API Token to use to connect to Snipe IT.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Uri
The API URI for a Snipe IT instance.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Disconnect-SnipeIT](Disconnect-SnipeIT.md)

[Generating API tokens for Snipe IT](https://snipe-it.readme.io/reference#generating-api-tokens)
