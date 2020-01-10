using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
)
# TODO: /locations
#           GET /{id}/users
#           GET /{id}/assets
#           GET /{id}/check
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
