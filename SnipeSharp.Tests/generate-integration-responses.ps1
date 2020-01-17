# Generate Integration Responses:
# This script should only be run against fresh installs of Snipe-IT, with only an admin account. See: docker
# How it works:
#    1. Filler data is populated into the instance in an explicit order,
#       respecting the partial ordering of dependencies:
#         - Category, Company, CustomField, Depreciation, FieldSet, Group, Manufacturer, StatusLabel, Supplier
#         - PATCH: FieldSet/CustomField associations
#         - Model, Location, License
#         - PATCH: Child Locations
#         - Accessory, Asset, Component, Consumable, Department
#         - User, AssetAudit
#         - PATCH: Location managers, Department managers, Assets checked out to users
#         - Consumable
#    2. Test information is loaded from CSV files; the tests are performed,
#       then the responses recorded to json files in a temporary directory,
#       and a mapping defined in generated C# files from c# names to test file names.
#    3. The temp directory is moved to the real location
#    4. In the C# tests, the tests are written to expect the exact data in the files.
#       If the mock data is changed, the tests must be updated to match.
using namespace System.IO
using namespace System.Text
using namespace System.Net.Http

PARAM (
    [Parameter(Mandatory=$true)][string]$Token,
    [Parameter(Mandatory=$true)][string]$Uri
)

# TODO: populate Resources/Integration with responses for integration testing.
# This script should only be run against fresh installs of Snipe-IT, with only an admin account. See: docker
function MakeDirectory
{
    PARAM ([string]$Path)
    if($PSVersionTable.OS -like 'Microsoft Windows*')
    {
        New-Item -ItemType Directory -Path $Path
    } else
    {
        # On Linux and Mac, use mkdir directly, 'cause I can't figure out how to set permissions
        $null = mkdir -m 0755 -p $Path
        Get-Item -LiteralPath $Path
    }
}
[hashtable]$Headers = @{
    Headers = @{
        Authorization = "Bearer $Token"
        'content-type' = 'application/json'
    }
    UseBasicParsing = $true
}
[string]$TempDirectoryPath = "$PSScriptRoot/Resources/_TempIntegration"
[string]$FinalDirectoryPath = "$PSScriptRoot/Resources/Integration"
[string]$RecoveryDirectoryPath = "$PSScriptRoot/Resources/_Integration"
if(Test-Path -LiteralPath $RecoveryDirectoryPath)
{
    throw 'Recovery directory Resources/_Integration exists. Please resolve any errors before re-generating integration responses.'
}
try
{
    if(Test-Path -LiteralPath $TempDirectoryPath)
    {
        Remove-Item -Recurse -Force -LiteralPath $TempDirectoryPath
    }
    [DirectoryInfo]$TempDirectory = MakeDirectory -Path $TempDirectoryPath

    # Populate the instance with test data
    # Data was mostly generated with https://mockaroo.com
    function Populate
    {
        PARAM (
            [Parameter(Mandatory=$true, ValueFromPipelineByPropertyName=$true)][string]$Path,
            [Parameter(Mandatory=$true, ValueFromPipelineByPropertyName=$true)][string]$Body
        )
        $null = Invoke-WebRequest @Headers -Uri "$Uri$Path" -Body $Body
    }
    Import-Csv "$PSScriptRoot/scripts/Populate/Companies.csv" | Populate
    Import-Csv "$PSScriptRoot/scripts/Populate/Accessories.csv" | Populate

    # now do requests and record results
    function Register-Test
    {
        # if the line (Name column) starts with #, the test will be skipped. If it starts with '-', the
        # "test" will be performed, but the results discard; this is useful for resetting something then
        # doing a similar action
        PARAM (
            [Parameter(Mandatory=$true, ValueFromPipelineByPropertyName=$true)][string]$Name,
            [Parameter(Mandatory=$true, ValueFromPipelineByPropertyName=$true)][ValidateSet('Get','Post','Put','Delete','Patch')][string]$Method,
            [Parameter(Mandatory=$true, ValueFromPipelineByPropertyName=$true)][string]$Path,
            [Parameter(ValueFromPipelineByPropertyName=$true)][string]$Body,
            [Parameter(Mandatory=$true)][StreamWriter]$Stream
        )
        if($Name[0] -ne '#')
        {
            if(!$Body)
            {
                $Body = $null
            }
            $JSONContent = Invoke-WebRequest @Headers -Uri "$Uri$Path" -Body $Body | Select-Object -ExpandProperty Content
            if($Name[0] -ne '-')
            {
                $Stream.Write("            internal const string $Name = ""./Resources/Integration/$Method$($Path -replace '/','_').$Name.json"";`n");
                [File]::WriteAllText((Join-Path -Path $TempDirectory.FullName -ChildPath $FileName), $JSONContent, [Encoding]::UTF8);
            }
        }
    }
    [FileInfo[]]$DataFiles = Get-Item -Path "$PSScriptRoot/scripts/Integration/*.csv"
    foreach($DataFile in $DataFiles)
    {
        # Make a new stream for the file $TempDir/Resources.TYPE.cs (UTF8) and write out the class info for each file
        [StreamWriter]$Stream = [StreamWriter]::new((Join-Path -Path $TempDirectory.FullName -ChildPath "Resources.$($DataFile.BaseName).cs"), $false, [Encoding]::UTF8)
        $Stream.Write("namespace SnipeSharp.Tests`n{`n    internal static partial class Resources`n    {`n        internal static class $($DataFile.BaseName)`n        {`n")
        # then read all the tests and gather data
        Import-Csv $DataFile.FullName | Register-Test -Stream $Stream
        # then clean up
        $Stream.Write("        }`n    }`n}`n")
        $Stream.Dispose()
    }

    # fin
    if(Test-Path -LiteralPath $FinalDirectoryPath)
    {
        $UsingRecovery = $true
        Move-Item -LiteralPath $FinalDirectoryPath -Destination $RecoveryDirectoryPath
    }
    Move-Item -LiteralPath $TempDirectory.FullName -Destination $FinalDirectoryPath
    if($UsingRecovery)
    {
        Remove-Item -Recurse -Force -LiteralPath $RecoveryDirectoryPath
    }
} catch
{
    Write-Error -ErrorRecord $_
    exit 1
}
