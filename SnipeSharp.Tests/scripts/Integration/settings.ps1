using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /settings
#           GET /ldaptest
#           POST /ldaptestlogin
#           POST /slacktest
#           POST /mailtest
