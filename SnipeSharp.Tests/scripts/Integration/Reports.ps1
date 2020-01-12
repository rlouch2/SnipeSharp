using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /reports
#           GET /activity
