using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory
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

Register-String 'Individual' -Path './Resources/Integration/GET_accessories.OneItem.json'
Register-String 'GetAll_PartOne' -Path './Resources/Integration/GET_accessories.PartOne.json'
Register-String 'GetAll_PartTwo' -Path './Resources/Integration/GET_accessories.PartTwo.json'
Register-String 'Create_Ok' -Path './Resource/Integration/POST_accessories.CreateOk.json'
Register-String 'Create_MissingName' -Path './Resources/Integration/POST_accessories.CreateMissingName.json'
Register-String 'Create_NameTooShort' -Path './Resources/Integration/POST_accessories.CreateNameTooShort.json'
Register-String 'Create_NameTooLong' -Path './Resources/Integration/POST_accessories.CreateNameTooLong.json'
Register-String 'Create_MissingQuantity' -Path './Resources/Integration/POST_accessories.CreateMissingQuantity.json'
Register-String 'Create_QuantityTooSmall' -Path './Resources/Integration/POST_accessories.CreateQuantityTooSmall.json'
Register-String 'Create_MissingCategory' -Path './Resources/Integration/POST_accessories.CreateMissingCategory.json'
Register-String 'Create_InvalidCategory' -Path './Resources/Integration/POST_accessories.CreateInvalidCategory.json'
Register-String 'Update_Ok' -Path './Resource/Integration/PATCH_accessories.UpdateOk.json'
Register-String 'Update_NotExist' -Path './Resource/Integration/PATCH_accessories.UpdateNotExist.json'
Register-String 'Update_MissingName' -Path './Resources/Integration/PATCH_accessories.UpdateMissingName.json'
Register-String 'Update_NameTooShort' -Path './Resources/Integration/PATCH_accessories.UpdateNameTooShort.json'
Register-String 'Update_NameTooLong' -Path './Resources/Integration/PATCH_accessories.UpdateNameTooLong.json'
Register-String 'Update_MissingQuantity' -Path './Resources/Integration/PATCH_accessories.UpdateMissingQuantity.json'
Register-String 'Update_QuantityTooSmall' -Path './Resources/Integration/PATCH_accessories.UpdateQuantityTooSmall.json'
Register-String 'Update_MissingCategory' -Path './Resources/Integration/PATCH_accessories.UpdateMissingCategory.json'
Register-String 'Update_InvalidCategory' -Path './Resources/Integration/PATCH_accessories.UpdateInvalidCategory.json'
Register-String 'Delete' -Path './Resources/Integration/DELETE_accessories.json'
Register-String 'GetCheckedOut' -Path './Resources/Integration/GET_accessories_checkedout.json'
Register-String 'CheckOut' -Path './Resources/Integration/POST_accessories_checkout.json'
Register-String 'CheckOut_UserNotExist' -Path './Resources/Integration/POST_accessories_checkout.UserNotExist.json'
Register-String 'CheckIn' -Path './Resources/Integration/POST_accessories_checkin.json'
Register-String 'CheckIn_UpdateName' -Path './Resources/Integration/POST_accessories_checkin.UpdateName.json'
