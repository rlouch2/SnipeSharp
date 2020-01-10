using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /licenses
#           GET /{id}/seats
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
