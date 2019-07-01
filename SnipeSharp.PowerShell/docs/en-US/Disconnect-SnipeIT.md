---
external help file: SnipeSharp.PowerShell.dll-Help.xml
Module Name: SnipeSharp.PowerShell
online version:
schema: 2.0.0
---

# Disconnect-SnipeIT

## SYNOPSIS
Ends the current session with Snipe IT.

## SYNTAX

```
Disconnect-SnipeIT [<CommonParameters>]
```

## DESCRIPTION
The Disconnect-SnipeIT cmdlet ends the current session with Snipe IT. This cmdlet does not throw any errors if there is no connected session.

## EXAMPLES

### Example 1
```powershell
PS C:\> Disconnect-SnipeIT
```

Disconnect from the current Snipe IT session, or verify that there isn't a current session.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[Connect-SnipeIT](Connect-SnipeIT.md)
