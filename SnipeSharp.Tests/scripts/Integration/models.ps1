using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /models
#           GET /assets
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
