using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /fieldsets
#           GET /{id}/fields
#           GET /{id}/fields/{model_id}
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
