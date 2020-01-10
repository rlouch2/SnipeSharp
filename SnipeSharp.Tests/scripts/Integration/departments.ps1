using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /departments
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
