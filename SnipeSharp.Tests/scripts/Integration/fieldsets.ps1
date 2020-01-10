using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
)
# TODO: /fieldsets
#           GET /{id}/fields
#           GET /{id}/fields/{model_id}
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
