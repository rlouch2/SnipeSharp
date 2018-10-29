#
# Module manifest for module 'SnipeSharp.PowerShell'
# Generated on: 7/23/2018
#
@{
  RootModule = 'SnipeSharp.PowerShell.dll'
  DefaultCommandPrefix = 'Snipe'

  # Version number of this module.
  ModuleVersion = '1.0'
  CompatiblePSEditions = @('5.1')

  # ID used to uniquely identify this module
  GUID = 'd16d3f92-561f-4c81-8cb2-73e11cbbff51'
  Author = 'Christian LaCourt' # TODO: include Barrey?

  # Company or vendor of this module
  CompanyName = 'Unknown'
  # Copyright statement for this module
  Copyright = '(c) 2018 Matthew Barrey and Christian LaCourt. MIT License.' # TODO: fix license line

  # Description of the functionality provided by this module
  Description = 'TODO'

  # Minimum version of the Windows PowerShell engine required by this module
  PowerShellVersion = '5.1'

  # Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
  DotNetFrameworkVersion = '4.6'

  # Assemblies that must be loaded prior to importing this module
  # RequiredAssemblies = @()

  TypesToProcess = 'SnipeSharp.PowerShell.dll-types.ps1xml'
  FormatsToProcess = 'SnipeSharp.PowerShell.dll-format.ps1xml'
  CmdletsToExport = @(
    'Connect-SnipeInstance'
    'Disconnect-SnipeInstance'
    'CheckIn-SnipeAsset'
    'CheckOut-SnipeAsset'
    'Get-SnipeAssignedAssets'
    'Get-SnipeAccessory'
    'Get-SnipeAsset'
    'Get-SnipeAssignedAsset'
    'Get-SnipeCategory'
    'Get-SnipeCompany'
    'Get-SnipeComponent'
    'Get-SnipeConsumable'
    'Get-SnipeDepartment'
    'Get-SnipeDepreciation'
    'Get-SnipeFieldSet'
    'Get-SnipeLicense'
    'Get-SnipeLocation'
    'Get-SnipeManufacturer'
    'Get-SnipeModel'
    'Get-SnipeStatusLabel'
    'Get-SnipeSupplier'
    'Get-SnipeUser'
    'Set-SnipeAccessory'
    'Set-SnipeAsset'
    'Set-SnipeAssignedAsset'
    'Set-SnipeCategory'
    'Set-SnipeCompany'
    'Set-SnipeComponent'
    'Set-SnipeConsumable'
    'Set-SnipeDepartment'
    'Set-SnipeDepreciation'
    'Set-SnipeFieldSet'
    'Set-SnipeLicense'
    'Set-SnipeLocation'
    'Set-SnipeManufacturer'
    'Set-SnipeModel'
    'Set-SnipeStatusLabel'
    'Set-SnipeSupplier'
    'Set-SnipeUser'
    'New-SnipeAccessory'
    'New-SnipeAsset'
    'New-SnipeAssignedAsset'
    'New-SnipeCategory'
    'New-SnipeCompany'
    'New-SnipeComponent'
    'New-SnipeConsumable'
    'New-SnipeDepartment'
    'New-SnipeDepreciation'
    'New-SnipeFieldSet'
    'New-SnipeLicense'
    'New-SnipeLocation'
    'New-SnipeManufacturer'
    'New-SnipeModel'
    'New-SnipeStatusLabel'
    'New-SnipeSupplier'
    'New-SnipeUser'
    'Find-SnipeAccessory'
    'Find-SnipeAsset'
    'Find-SnipeAssignedAsset'
    'Find-SnipeCategory'
    'Find-SnipeCompany'
    'Find-SnipeComponent'
    'Find-SnipeConsumable'
    'Find-SnipeDepartment'
    'Find-SnipeDepreciation'
    'Find-SnipeFieldSet'
    'Find-SnipeLicense'
    'Find-SnipeLocation'
    'Find-SnipeManufacturer'
    'Find-SnipeModel'
    'Find-SnipeStatusLabel'
    'Find-SnipeSupplier'
    'Find-SnipeUser'
    'Remove-SnipeAccessory'
    'Remove-SnipeAsset'
    'Remove-SnipeAssignedAsset'
    'Remove-SnipeCategory'
    'Remove-SnipeCompany'
    'Remove-SnipeComponent'
    'Remove-SnipeConsumable'
    'Remove-SnipeDepartment'
    'Remove-SnipeDepreciation'
    'Remove-SnipeFieldSet'
    'Remove-SnipeLicense'
    'Remove-SnipeLocation'
    'Remove-SnipeManufacturer'
    'Remove-SnipeModel'
    'Remove-SnipeStatusLabel'
    'Remove-SnipeSupplier'
    'Remove-SnipeUser'
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
