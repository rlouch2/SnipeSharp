using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /users
#           POST /two_factor_reset
#           GET /me
#           GET /list/{status?}
#           GET /{id}/assets
#           GET /{id}/accessories
#           GET /{id}/licenses
#           GET /{id}/upload
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
