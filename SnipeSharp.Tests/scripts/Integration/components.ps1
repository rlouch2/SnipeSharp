using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /components
#           GET /{id}/assets
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
