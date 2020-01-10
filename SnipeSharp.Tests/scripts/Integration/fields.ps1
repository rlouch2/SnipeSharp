using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /fields
#           POST /fieldsets/{id}/order
#           POST /{id}/associate
#           POST /{id}/disassociate
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
