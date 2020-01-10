using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /maintenances
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
