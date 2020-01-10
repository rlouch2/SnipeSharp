using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidateNotNull()]
    [DirectoryInfo]$Directory
)
# TODO: /hardware
#           GET /bytag/{tag}
#           GET /byserial/{serial}
#           GET /audit/{audit}
#           POST /audit
#           POST /{id}/checkout
#           POST /{id}/checkin
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
