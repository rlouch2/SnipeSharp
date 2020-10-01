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

task Test Clean, Build, {
    Push-Location "$PSScriptRoot/test/docker"
    docker-compose up --build --detach
    Pop-Location
    $MainContainer = (docker ps | Where-Object { $_ -match '\bsnipesharp-snipeit-test\b' }) -split '\s\s+'
    $null = $MainContainer[5] -match '0.0.0.0:(\d+)->80/tcp'
    $env:SnipeSharp_TestSite = "http://localhost:$($Matches[1])/api/v1"
    $Variables = @{}
    foreach($Line in Get-Content "$PSScriptRoot/test/docker/.env" | Where-Object { $_ -cmatch '^[A-Z]' })
    {
        $Key, $Value = $Line -split '='
        $Variables[$Key] = $Value
        [Environment]::SetEnvironmentVariable("SnipeSharp_$Key", $Value, 'Process')
    }
    $env:SnipeSharp_TestToken = docker exec $MainContainer[0] '/get-token.sh'
    $TestParameters = @(
        "$PSScriptRoot/test/SnipeSharp.Test/SnipeSharp.Test.csproj"
        '/consoleloggerparameters:NoSummary'
        '/p:CollectCoverage=true'
        '/p:CoverletOutputFormat=\"opencover,lcov\"'
        "/p:CoverletOutput=$PSScriptRoot/"
    )
    dotnet test @TestParameters
    Push-Location "$PSScriptRoot/test/docker"
    docker-compose down --volumes
    Pop-Location
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

task Build Restore, {
    dotnet build
}

task Restore {
    dotnet restore
}

task . Test
