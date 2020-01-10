using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /companies
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
