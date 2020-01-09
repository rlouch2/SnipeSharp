#
# Module manifest for module 'SnipeSharp.PowerShell'
# Generated on: 7/23/2018
#
@{
    RootModule = 'SnipeSharp.PowerShell.dll'
    DefaultCommandPrefix = 'Snipe'

    # Version number of this module.
    ModuleVersion = '0.0.3'
    CompatiblePSEditions = @('5.1')

    # ID used to uniquely identify this module
    GUID = 'd16d3f92-561f-4c81-8cb2-73e11cbbff51'
    Author = 'Christian LaCourt' # TODO: include Barrey?

    # Company or vendor of this module
    CompanyName = 'Unknown'
    # Copyright statement for this module
    Copyright = '(c) 2018 Matthew Barrey and Christian LaCourt. MIT License.' # TODO: fix license line

    # Description of the functionality provided by this module
    Description = 'The SnipeSharp.PowerShell module allows the management of SnipeIT with PowerShell using the SnipeSharp library.'

    # Minimum version of the Windows PowerShell engine required by this module
    PowerShellVersion = '5.1'

    # Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
    DotNetFrameworkVersion = '4.6'

    # Assemblies that must be loaded prior to importing this module
    # RequiredAssemblies = @()

    TypesToProcess = 'SnipeSharp.PowerShell.dll-types.ps1xml'
    FormatsToProcess = 'SnipeSharp.PowerShell.dll-format.ps1xml'
    CmdletsToExport = @(
        'Connect-IT'
        'Disconnect-IT'
        'CheckIn-Accessory'
        'CheckOut-Accessory'
        'CheckIn-Asset'
        'CheckOut-Asset'
        'Get-Accessory'
        'Get-Asset'
        'Get-AssignedAccessory'
        'Get-AssignedAsset'
        'Get-Category'
        'Get-Company'
        'Get-Component'
        'Get-Consumable'
        'Get-CustomField'
        'Get-Department'
        'Get-Depreciation'
        'Get-FieldSet'
        'Get-License'
        'Get-LicenseSeat'
        'Get-Location'
        'Get-Manufacturer'
        'Get-Model'
        'Get-Request'
        'Get-StatusLabel'
        'Get-Supplier'
        'Get-User'
        'Set-Accessory'
        'Set-Asset'
        'Set-AssignedAsset'
        'Set-Category'
        'Set-Company'
        'Set-Component'
        'Set-Consumable'
        'Set-CustomField'
        'Set-Department'
        'Set-Depreciation'
        'Set-FieldSet'
        'Set-FieldSetOrder'
        'Set-License'
        'Set-Location'
        'Set-Manufacturer'
        'Set-Model'
        'Set-StatusLabel'
        'Set-Supplier'
        'Set-User'
        'New-Accessory'
        'New-Asset'
        'New-AssignedAsset'
        'New-Category'
        'New-Company'
        'New-Component'
        'New-Consumable'
        'New-CustomField'
        'New-Department'
        'New-Depreciation'
        'New-FieldSet'
        'New-License'
        'New-Location'
        'New-Manufacturer'
        'New-Model'
        'New-StatusLabel'
        'New-Supplier'
        'New-User'
        'Find-Accessory'
        'Find-Asset'
        'Find-AssignedAsset'
        'Find-Category'
        'Find-Company'
        'Find-Component'
        'Find-Consumable'
        'Find-CustomField'
        'Find-Department'
        'Find-Depreciation'
        'Find-FieldSet'
        'Find-License'
        'Find-Location'
        'Find-Manufacturer'
        'Find-Model'
        'Find-RequestableAsset'
        'Find-StatusLabel'
        'Find-Supplier'
        'Find-User'
        'Invoke-AssetAudit'
        'Remove-Accessory'
        'Remove-Asset'
        'Remove-AssignedAsset'
        'Remove-Category'
        'Remove-Company'
        'Remove-Component'
        'Remove-Consumable'
        'Remove-CustomField'
        'Remove-Department'
        'Remove-Depreciation'
        'Remove-FieldSet'
        'Remove-License'
        'Remove-Location'
        'Remove-Manufacturer'
        'Remove-Model'
        'Remove-StatusLabel'
        'Remove-Supplier'
        'Remove-User'
    )

    # Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
    PrivateData = @{
        PSData = @{
            # Tags applied to this module. These help with module discovery in online galleries.
            # Tags = @()

            # A URL to the license for this module.
            # LicenseUri = ''

            # A URL to the main website for this project.
            # ProjectUri = ''

            # A URL to an icon representing this module.
            # IconUri = ''

            # ReleaseNotes of this module
            # ReleaseNotes = ''
        }
    }

    # HelpInfo URI of this module
    # HelpInfoURI = ''
}
