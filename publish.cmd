echo off
echo #--------------------------------------
echo # Publish to nuget.org
echo #--------------------------------------

rem Remarks:
rem  Please Set NUGET_APIKEY env varible on your computer

rem clean packages
del .\src\bin\Release\*.nupkg

rem pack
dotnet pack ".\src\NdExtension.ProjectTemplates.csproj" -c Release 

rem push
cd src\bin\Release
dotnet nuget push "*.nupkg" --source https://api.nuget.org/v3/index.json --skip-duplicate --api-key %NUGET_APIKEY%


pause
