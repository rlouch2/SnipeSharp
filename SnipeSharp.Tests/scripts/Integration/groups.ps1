using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /groups
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
