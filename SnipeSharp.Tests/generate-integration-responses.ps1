using namespace System.IO
using namespace System.Text
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

    [FileInfo[]]$Scripts = Get-Item -Path "$PSScriptRoot/scripts/Integration/*.ps1"
    foreach($Script in $Scripts)
    {
        [FileInfo]$ScriptFile = $Script
        [FileInfo]$CsFile = Get-Item -LiteralPath (Join-Path -Path $TempDirectory.FullName -ChildPath "Resources.$($ScriptFile.BaseName).cs" )
        [StreamWriter]$Stream = $CsFile.CreateText()
        $Stream.Encoding = [Encoding]::UTF8
        $Stream.Write("namespace SnipeSharp.Tests`n{`n")
        $Stream.Write("    internal static partial class Resources`n    {`n")
        $Stream.Write("        internal static class $($ScriptFile.BaseName)`n        {`n")
        & $ScriptFile.FullName -Directory $TempDirectory -ResourceStream $Stream
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
