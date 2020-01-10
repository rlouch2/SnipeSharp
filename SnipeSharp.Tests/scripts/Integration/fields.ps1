using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
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
