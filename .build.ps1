#Requires -Modules InvokeBuild
$DockerComposeFile = "$PSScriptRoot/test/docker/docker-compose.yml"

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

function TestUp {
    docker compose -f $DockerComposeFile up --build --detach
    $MainContainer = (docker ps | Where-Object { $_ -match '\bsnipesharp-snipeit-test\b' }) -split '\s\s+'
    $null = $MainContainer[5] -match '0.0.0.0:(\d+)->80/tcp'
    $env:SnipeSharp_TestSite = "http://localhost:$($Matches[1])/api/v1"
    $env:SnipeSharp_TestToken = docker exec $MainContainer[0] '/get-token.sh'
    $Variables = @{}
    foreach($Line in Get-Content "$PSScriptRoot/test/docker/.env" | Where-Object { $_ -cmatch '^[A-Z]' })
    {
        $Key, $Value = $Line -split '='
        $Variables[$Key] = $Value
        [Environment]::SetEnvironmentVariable("SnipeSharp_$Key", $Value, 'Process')
    }
}

task TestUp {
    TestUp
    Write-Host "Site:  $env:SnipeSharp_TestSite"
    Write-Host "Token: $env:SnipeSharp_TestToken"
}

function TestDown {
    docker compose -f $DockerComposeFile down --volumes
}

task TestDown $Function:TestDown

task Test Clean, Build, {
    TestUp
    $TestParameters = @(
        "$PSScriptRoot/test/SnipeSharp.Test/SnipeSharp.Test.csproj"
        '/consoleloggerparameters:NoSummary'
        '/p:CollectCoverage=true'
        '/p:CoverletOutputFormat=\"opencover,lcov\"'
        "/p:CoverletOutput=$PSScriptRoot/"
    )
    dotnet test @TestParameters
    TestDown
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
