using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
)
# TODO: /statuslabels
#           GET /assets
#           GET /{id}/assetlist
#           GET /{id}/deployable
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
