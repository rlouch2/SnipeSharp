#Requires -Modules platyPS

using namespace System.Text;

[CmdletBinding()]
PARAM (

)

[string]$Bin = if(Test-Path "$PSScriptRoot/bin/Release") { "$PSScriptRoot/bin/Release" } else { "$PSScriptRoot/bin/Debug" }
if(!(Test-Path $Bin)) {
    throw "The project must be built before documentation can be generated."
}

$ModuleManifestFile = Get-ChildItem -Path $Bin -Recurse -Filter '*.psd1' | Where-Object { Test-ModuleManifest -Path $_.FullName -ErrorAction SilentlyContinue } | Select-Object -First 1
if($null -eq $ModuleManifestFile) {
    throw "No module manifest was found in ""$Bin"". Have you built the project?"
}

[string]$DocumentRoot = "$PSScriptRoot/docs"
[string]$Locale = "en-US"
[Encoding]$Encoding = [Encoding]::UTF8
[string]$ModuleOutDir = $ModuleManifestFile.DirectoryName

[string]$ModuleName = $ModuleManifestFile.BaseName
try {
    $ModuleInfo = Import-Module $ModuleManifestFile.FullName -Force -PassThru
    $ModuleManifest = Import-PowerShellDataFile $ModuleManifestFile.FullName
    if($ModuleInfo.ExportedCommands.Count -eq 0) {
        Write-Output "The module $ModuleName exports no commands, exiting."
        return
    }

    if(!(Test-Path -LiteralPath $DocumentRoot)) {
        $null = mkdir $DocumentRoot -Verbose:$VerbosePreference
    }

    if(Get-ChildItem -LiteralPath $DocumentRoot -Filter '*.md' -Recurse -ErrorAction SilentlyContinue) {
        Get-ChildItem -LiteralPath $DocumentRoot -Directory | ForEach-Object {
            $null = Update-MarkdownHelp -Path $_.FullName -Verbose:$VerbosePreference
        }
    }

    $Parameters = @{
        AlphabeticParamsOrder = $true
        Encoding = $Encoding
        # FwLink = $FwLink
        HelpVersion = $ModuleManifest.ModuleVersion
        Locale = $Locale
        Module = $ModuleName
        OutputFolder = "$DocumentRoot/$Locale"
        WithModulePage = $true
    }
    $null = New-MarkdownHelp @Parameters -ErrorAction SilentlyContinue -Verbose:$VerbosePreference

    Get-ChildItem -Path $DocumentRoot -Directory | Select-Object -ExpandProperty Name | ForEach-Object {
        $null = New-ExternalHelp -Path "$DocumentRoot/$_" -OutputPath "$ModuleOutdir/$_" -Force -ErrorAction SilentlyContinue -Verbose:$VerbosePreference -Encoding $Encoding
    }

    if(Test-Path -Path "$ModuleOutDir/$ModuleName.cat")
    {
        $null = Remove-Item -Path "$ModuleOutdir/$ModuleName.cat"
    }
    $null = New-FileCatalog -Path $ModuleOutDir -CatalogFilePath "$ModuleOutDir/$ModuleName.cat" -CatalogVersion 2
} finally {
    Remove-Module -Name $ModuleName -Force
}
