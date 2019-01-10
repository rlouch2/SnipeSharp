---
Module Name: SnipeSharp.PowerShell
Module Guid: d16d3f92-561f-4c81-8cb2-73e11cbbff51
Download Help Link: {{Please enter FwLink manually}}
Help Version: 1.0
Locale: en-US
---

# SnipeSharp.PowerShell Module
## Description
The SnipeSharp.PowerShell module allows the management of SnipeIT with PowerShell using the SnipeSharp library.

## SnipeSharp.PowerShell Cmdlets
### [CheckIn-SnipeAsset](CheckIn-SnipeAsset.md)
The CheckIn-Asset cmdlet checks in one or more asset objects.

### [CheckOut-SnipeAsset](CheckOut-SnipeAsset.md)
The CheckOut-Asset cmdlet checks out an asset to a user, location, or another asset.

### [Connect-SnipeIT](Connect-SnipeIT.md)
## DESCRIPTION
The Connect-SnipeIT cmdlet begins a session with a Snipe IT instance.

You may only have one SnipeIT session per PowerShell session.

### [Disconnect-SnipeIT](Disconnect-SnipeIT.md)
The Disconnect-SnipeIT cmdlet ends the current session with Snipe IT. This cmdlet does not throw any errors if there is no connected session.

### [Find-SnipeAccessory](Find-SnipeAccessory.md)
The Find-Accessory cmdlet finds accessory objects by filter, company, category, manufacturer, or supplier.

### [Find-SnipeAsset](Find-SnipeAsset.md)
The Find-Asset cmdlet finds asset objects by filter.

### [Find-SnipeCategory](Find-SnipeCategory.md)
The Find-Category cmdlet finds category objects by filter.

### [Find-SnipeCompany](Find-SnipeCompany.md)
The Find-Company cmdlet finds company objects by filter.

### [Find-SnipeComponent](Find-SnipeComponent.md)
The Find-Component cmdlet finds component objects by filter.

### [Find-SnipeConsumable](Find-SnipeConsumable.md)
The Find-Consumable cmdlet finds consumable objects by filter.

### [Find-SnipeCustomField](Find-SnipeCustomField.md)
The Find-CustomField cmdlet finds custom fields by filter.

### [Find-SnipeDepartment](Find-SnipeDepartment.md)
The Find-Asset cmdlet finds departments by filter.

### [Find-SnipeDepreciation](Find-SnipeDepreciation.md)
The Find-Depreciation cmdlet finds depreciations by filter.

### [Find-SnipeFieldSet](Find-SnipeFieldSet.md)
The Find-FieldSet cmdlet finds custom field sets by filter.

### [Find-SnipeLicense](Find-SnipeLicense.md)
The Find-License cmdlet finds license objects by filter.

### [Find-SnipeLocation](Find-SnipeLocation.md)
The Find-Asset cmdlet finds location objects by filter.

### [Find-SnipeManufacturer](Find-SnipeManufacturer.md)
The Find-Asset cmdlet finds manufacturer objects by filter.

### [Find-SnipeModel](Find-SnipeModel.md)
The Find-Model cmdlet finds model objects by filter.

### [Find-SnipeStatusLabel](Find-SnipeStatusLabel.md)
The Find-StatusLabel cmdlet finds status label objects by filter.

### [Find-SnipeSupplier](Find-SnipeSupplier.md)
The Find-Supplier cmdlet finds supplier objects by filter.

### [Find-SnipeUser](Find-SnipeUser.md)
The Find-User cmdlet finds user objects by filter, company, location, group, or department.

### [Get-SnipeAccessory](Get-SnipeAccessory.md)
The Get-Accessory cmdlet gets one or more accessory objects by name or by Snipe-IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeAsset](Get-SnipeAsset.md)
The Get-Asset cmdlet gets one or more asset objects.

The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.

### [Get-SnipeAssignedAsset](Get-SnipeAssignedAsset.md)
The Get-AssignedAsset cmdlet get, for each user provided, the asset objects associated with that user.

### [Get-SnipeCategory](Get-SnipeCategory.md)
The Get-Category cmdlet gets one or more category objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeCompany](Get-SnipeCompany.md)
The Get-Company cmdlet gets one or more company objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeComponent](Get-SnipeComponent.md)
The Get-Component cmdlet gets one or more component objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeConsumable](Get-SnipeConsumable.md)
The Get-Consumable cmdlet gets one or more consumable objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeCustomField](Get-SnipeCustomField.md)
The Get-CustomField cmdlet gets one or more custom field objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeDepartment](Get-SnipeDepartment.md)
The Get-Department cmdlet gets one or more department objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeDepreciation](Get-SnipeDepreciation.md)
The Get-Depreciation cmdlet gets one or more depreciation objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeFieldSet](Get-SnipeFieldSet.md)
The Get-FieldSet cmdlet gets one or more fieldset objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeLicense](Get-SnipeLicense.md)
The Get-License cmdlet gets one or more license objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeLocation](Get-SnipeLocation.md)
The Get-Location cmdlet gets one or more location objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeManufacturer](Get-SnipeManufacturer.md)
The Get-Manufacturer cmdlet gets one or more manufacturer objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeModel](Get-SnipeModel.md)
The Get-Model cmdlet gets one or more model objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeStatusLabel](Get-SnipeStatusLabel.md)
The Get-StatusLabel cmdlet gets one or more status label objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeSupplier](Get-SnipeSupplier.md)
The Get-Supplier cmdlet gets one or more supplier objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [Get-SnipeUser](Get-SnipeUser.md)
The Get-User cmdlet gets one or more user objects by name or by Snipe IT internal id number.

Whatever identifier is used, both accept pipeline input.

### [New-SnipeAccessory](New-SnipeAccessory.md)
The New-Accessory cmdlet creates a new accessory object.

### [New-SnipeAsset](New-SnipeAsset.md)
The New-Asset cmdlet creates a new asset object.

### [New-SnipeCategory](New-SnipeCategory.md)
The New-Category cmdlet creates a new category object.

### [New-SnipeCompany](New-SnipeCompany.md)
The New-Company cmdlet creates a new company object.

### [New-SnipeComponent](New-SnipeComponent.md)
The New-Component cmdlet creates a new component object.

### [New-SnipeConsumable](New-SnipeConsumable.md)
The New-Consumable cmdlet creates a new consumable object.

### [New-SnipeCustomField](New-SnipeCustomField.md)
The New-CustomField cmdlet creates a new custom field object, but does not associate it with any field sets.

### [New-SnipeDepartment](New-SnipeDepartment.md)
The New-Department cmdlet creates a new department object.

### [New-SnipeDepreciation](New-SnipeDepreciation.md)
The New-Depreciation cmdlet creates a new depreciation object.

### [New-SnipeFieldSet](New-SnipeFieldSet.md)
The New-FieldSet cmdlet creates a new field set object.

### [New-SnipeLicense](New-SnipeLicense.md)
The New-License cmdlet creates a new license object.

### [New-SnipeLocation](New-SnipeLocation.md)
The New-Location cmdlet creates a new location object.

### [New-SnipeManufacturer](New-SnipeManufacturer.md)
The New-Manufacturer cmdlet creates a new manufacturer object.

### [New-SnipeModel](New-SnipeModel.md)
The New-Model cmdlet creates a new model object.

### [New-SnipeStatusLabel](New-SnipeStatusLabel.md)
The New-StatusLabel cmdlet creates a new status label object.

### [New-SnipeSupplier](New-SnipeSupplier.md)
The New-Supplier cmdlet creates a new supplier object.

### [New-SnipeUser](New-SnipeUser.md)
The New-User cmdlet creates a new user object.

### [Remove-SnipeAccessory](Remove-SnipeAccessory.md)
The Remove-Accessory cmdlet removes one or more accessory objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeAsset](Remove-SnipeAsset.md)
The Remove-Asset cmdlet removes one or more asset objects from the Snipe IT database.

The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.

### [Remove-SnipeCategory](Remove-SnipeCategory.md)
The Remove-Category cmdlet removes one or more Category objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeCompany](Remove-SnipeCompany.md)
The Remove-Company cmdlet removes one or more Company objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeComponent](Remove-SnipeComponent.md)
The Remove-Component cmdlet removes one or more Component objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeConsumable](Remove-SnipeConsumable.md)
The Remove-Consumable cmdlet removes one or more Consumable objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeCustomField](Remove-SnipeCustomField.md)
The Remove-FieldSet cmdlet removes one or more custom field objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeDepartment](Remove-SnipeDepartment.md)
The Remove-Department cmdlet removes one or more Department objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeDepreciation](Remove-SnipeDepreciation.md)
The Remove-Depreciation cmdlet removes one or more Depreciation objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeFieldSet](Remove-SnipeFieldSet.md)
The Remove-FieldSet cmdlet removes one or more FieldSet objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeLicense](Remove-SnipeLicense.md)
The Remove-License cmdlet removes one or more License objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeLocation](Remove-SnipeLocation.md)
The Remove-Location cmdlet removes one or more Location objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeManufacturer](Remove-SnipeManufacturer.md)
The Remove-Manufacturer cmdlet removes one or more Manufacturer objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeModel](Remove-SnipeModel.md)
The Remove-Model cmdlet removes one or more Model objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeStatusLabel](Remove-SnipeStatusLabel.md)
The Remove-StatusLabel cmdlet removes one or more StatusLabel objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeSupplier](Remove-SnipeSupplier.md)
The Remove-Supplier cmdlet removes one or more Supplier objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Remove-SnipeUser](Remove-SnipeUser.md)
The Remove-User cmdlet removes one or more User objects by name or by Snipe IT internal id number from the Snipe IT database.

Whatever identifier is used, both accept pipeline input.

### [Set-SnipeAccessory](Set-SnipeAccessory.md)
The Set-Accessory cmdlet changes the properties of an existing Snipe-IT accessory object.

### [Set-SnipeAsset](Set-SnipeAsset.md)
The Set-Asset cmdlet changes the properties of an existing Snipe-IT asset object.

### [Set-SnipeCategory](Set-SnipeCategory.md)
The Set-Category cmdlet changes the properties of an existing Snipe-IT category object.

### [Set-SnipeCompany](Set-SnipeCompany.md)
The Set-Company cmdlet changes the properties of an existing Snipe-IT company object.

### [Set-SnipeComponent](Set-SnipeComponent.md)
The Set-Component cmdlet changes the properties of an existing Snipe-IT component object.

### [Set-SnipeConsumable](Set-SnipeConsumable.md)
The Set-Consumable cmdlet changes the properties of an existing Snipe-IT consumable object.

### [Set-SnipeCustomField](Set-SnipeCustomField.md)
The Set-CustomField cmdlet changes the properties of an existing Snipe-IT custom field object.

### [Set-SnipeDepartment](Set-SnipeDepartment.md)
The Set-Department cmdlet changes the properties of an existing Snipe-IT department object.

### [Set-SnipeDepreciation](Set-SnipeDepreciation.md)
The Set-Depreciation cmdlet changes the properties of an existing Snipe-IT depreciation object.

### [Set-SnipeFieldSet](Set-SnipeFieldSet.md)
The Set-FieldSet cmdlet changes the properties of an existing Snipe-IT field set object.

### [Set-SnipeFieldSetOrder](Set-SnipeFieldSetOrder.md)
The Set-FieldSetOrder cmdlet changes the order of custom fields in an existing Snipe-IT field set object.

### [Set-SnipeLicense](Set-SnipeLicense.md)
The Set-License cmdlet changes the properties of an existing Snipe-IT license object.

### [Set-SnipeLocation](Set-SnipeLocation.md)
The Set-Location cmdlet changes the properties of an existing Snipe-IT location object.

### [Set-SnipeManufacturer](Set-SnipeManufacturer.md)
The Set-Manufacturer cmdlet changes the properties of an existing Snipe-IT manufacturer object.

### [Set-SnipeModel](Set-SnipeModel.md)
The Set-Model cmdlet changes the properties of an existing Snipe-IT model object.

### [Set-SnipeStatusLabel](Set-SnipeStatusLabel.md)
The Set-StatusLabel cmdlet changes the properties of an existing Snipe-IT status label object.

### [Set-SnipeSupplier](Set-SnipeSupplier.md)
The Set-Supplier cmdlet changes the properties of an existing Snipe-IT supplier object.

### [Set-SnipeUser](Set-SnipeUser.md)
The Set-User cmdlet changes the properties of an existing Snipe-IT user object.
