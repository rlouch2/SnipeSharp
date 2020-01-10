using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
)
# TODO: /accessories
#           GET /{id}/checkedout
#           POST /{id}/checkout
#           POST /{id}/checkin
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}

$ResourceStream.Write("            internal const string Individual = ""./Resources/Integration/GET_accessories.OneItem.json"";`n")
$ResourceStream.Write("            internal const string GetAll_PartOne = ""./Resources/Integration/GET_accessories.PartOne.json"";`n")
$ResourceStream.Write("            internal const string GetAll_PartTwo = ""./Resources/Integration/GET_accessories.PartTwo.json"";`n")
$ResourceStream.Write("            internal const string Create_Ok = ""./Resource/Integration/POST_accessories.CreateOk.json"";`n")
$ResourceStream.Write("            internal const string Create_MissingName = ""./Resources/Integration/POST_accessories.CreateMissingName.json"";`n")
$ResourceStream.Write("            internal const string Create_NameTooShort = ""./Resources/Integration/POST_accessories.CreateNameTooShort.json"";`n")
$ResourceStream.Write("            internal const string Create_NameTooLong = ""./Resources/Integration/POST_accessories.CreateNameTooLong.json"";`n")
$ResourceStream.Write("            internal const string Create_MissingQuantity = ""./Resources/Integration/POST_accessories.CreateMissingQuantity.json"";`n")
$ResourceStream.Write("            internal const string Create_QuantityTooSmall = ""./Resources/Integration/POST_accessories.CreateQuantityTooSmall.json"";`n")
$ResourceStream.Write("            internal const string Create_MissingCategory = ""./Resources/Integration/POST_accessories.CreateMissingCategory.json"";`n")
$ResourceStream.Write("            internal const string Create_InvalidCategory = ""./Resources/Integration/POST_accessories.CreateInvalidCategory.json"";`n")
$ResourceStream.Write("            internal const string Update_Ok = ""./Resource/Integration/PATCH_accessories.UpdateOk.json"";`n")
$ResourceStream.Write("            internal const string Update_NotExist = ""./Resource/Integration/PATCH_accessories.UpdateNotExist.json"";`n")
$ResourceStream.Write("            internal const string Update_MissingName = ""./Resources/Integration/PATCH_accessories.UpdateMissingName.json"";`n")
$ResourceStream.Write("            internal const string Update_NameTooShort = ""./Resources/Integration/PATCH_accessories.UpdateNameTooShort.json"";`n")
$ResourceStream.Write("            internal const string Update_NameTooLong = ""./Resources/Integration/PATCH_accessories.UpdateNameTooLong.json"";`n")
$ResourceStream.Write("            internal const string Update_MissingQuantity = ""./Resources/Integration/PATCH_accessories.UpdateMissingQuantity.json"";`n")
$ResourceStream.Write("            internal const string Update_QuantityTooSmall = ""./Resources/Integration/PATCH_accessories.UpdateQuantityTooSmall.json"";`n")
$ResourceStream.Write("            internal const string Update_MissingCategory = ""./Resources/Integration/PATCH_accessories.UpdateMissingCategory.json"";`n")
$ResourceStream.Write("            internal const string Update_InvalidCategory = ""./Resources/Integration/PATCH_accessories.UpdateInvalidCategory.json"";`n")
$ResourceStream.Write("            internal const string Delete = ""./Resources/Integration/DELETE_accessories.json"";`n")
$ResourceStream.Write("            internal const string GetCheckedOut = ""./Resources/Integration/GET_accessories_checkedout.json;`n")
$ResourceStream.Write("            internal const string CheckOut = ""./Resources/Integration/POST_accessories_checkout.json"";`n")
$ResourceStream.Write("            internal const string CheckOut_UserNotExist = ""./Resources/Integration/POST_accessories_checkout.UserNotExist.json"";`n")
$ResourceStream.Write("            internal const string CheckIn = ""./Resources/Integration/POST_accessories_checkin.json"";`n")
$ResourceStream.Write("            internal const string CheckIn_UpdateName = ""./Resources/Integration/POST_accessories_checkin.UpdateName.json"";`n")
