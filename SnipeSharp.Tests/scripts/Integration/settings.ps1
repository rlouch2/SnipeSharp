using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
)
# TODO: /settings
#           GET /ldaptest
#           POST /ldaptestlogin
#           POST /slacktest
#           POST /mailtest
