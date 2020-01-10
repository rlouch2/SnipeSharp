using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /companies
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
