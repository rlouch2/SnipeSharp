using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
)
# TODO: /maintenances
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
