using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
)
# TODO: /consumables
#           GET /view/{id}/users
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
