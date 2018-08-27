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
    '*' # TODO: for testing, export everything, but once all the cmdlets are in get rid of this!
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
