#Requires -Modules InvokeBuild

task Coverage CoverageReport
task CoverageReport Restore, Test, {
    $Parameters = @(
        "-reports:$PSSCriptRoot/coverage.opencover.xml"
        "-targetdir:$PSScriptRoot/coveragereport"
    )
    Push-Location "$PSScriptRoot/test/SnipeSharp.Test"
    dotnet reportgenerator @Parameters
    Pop-Location
}
task CoverageGutters Restore, Test, {

}

task Test Clean, {
    $Parameters = @(
        "$PSScriptRoot/test/SnipeSharp.Test/SnipeSharp.Test.csproj"
        '/consoleloggerparameters:NoSummary'
        '/p:CollectCoverage=true'
        '/p:CoverletOutputFormat=\"opencover,lcov\"'
        "/p:CoverletOutput=$PSScriptRoot/"
    )
    dotnet test @Parameters
}

task Clean {
    $Items = @(
        "$PSScriptRoot/coveragereport"
        "$PSScriptRoot/OpenCoverxml"
    )
    foreach($Item in $Items){
        if(Test-Path $Item){
            Remove-Item $Item -Recurse
        }
    }
}

task Restore {
    dotnet restore
}

task . Test
