param (
    [string]$BannerlordDir = "C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord"
)

$ErrorActionPreference = "Stop"
$RootDir =$PSScriptRoot
Set-Location $RootDir

$McmVersion = "5.9.2"
$McmDir = Join-Path $RootDir ".build-tools\mcm"
$McmDll = Join-Path $McmDir "MCMv5.dll"

if (-Not (Test-Path $McmDll)) {
    Write-Host "Downloading MCM v$McmVersion for build..."
    New-Item -ItemType Directory -Force -Path $McmDir | Out-Null
    $ZipPath = Join-Path $McmDir "mcm.zip"
    Invoke-WebRequest -Uri "https://www.nuget.org/api/v2/package/Bannerlord.MCM/$McmVersion" -OutFile $ZipPath
    Expand-Archive -Path $ZipPath -DestinationPath $McmDir -Force
    Move-Item -Path (Join-Path $McmDir "lib\netstandard2.0\MCMv5.dll") -Destination $McmDll -Force
    Remove-Item -Recurse -Force (Join-Path $McmDir "lib")
    Remove-Item -Recurse -Force (Join-Path $McmDir "package")
    Remove-Item -Recurse -Force (Join-Path $McmDir "_rels")
    Remove-Item -Force $ZipPath
}

msbuild AutoCohesion.csproj /t:Rebuild /p:Configuration=Release "/p:BannerlordInstallDir=$BannerlordDir"

if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed"
    exit $LASTEXITCODE
}

$DistDir = Join-Path$RootDir "dist\AutoCohesion"
if (Test-Path $DistDir) { Remove-Item -Recurse -Force$DistDir }
$BinDir = Join-Path$DistDir "bin\Win64_Shipping_Client"
New-Item -ItemType Directory -Force -Path $BinDir | Out-Null
$ModuleDataDir = Join-Path$DistDir "ModuleData"
New-Item -ItemType Directory -Force -Path $ModuleDataDir | Out-Null

Copy-Item (Join-Path $RootDir "bin\Release\AutoCohesion.dll") -Destination $BinDir

Copy-Item (Join-Path $RootDir "SubModule.xml") -Destination $DistDir
Copy-Item (Join-Path $RootDir "ModuleData\*") -Destination $ModuleDataDir -Recurse

Write-Host "Built self-contained dist\AutoCohesion"
