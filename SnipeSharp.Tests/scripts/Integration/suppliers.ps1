using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /suppliers
#           GET /list
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
