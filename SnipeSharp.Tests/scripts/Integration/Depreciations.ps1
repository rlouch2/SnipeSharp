using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /depreciations
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
