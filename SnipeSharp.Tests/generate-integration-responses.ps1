using namespace System.IO
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
    # now do requests and record results

    & "$PSScriptRoot/scripts/Integration/connecting.ps1" -Directory $TempDirectory

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
