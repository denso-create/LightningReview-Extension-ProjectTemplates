
rem uninstall templates
dotnet new --uninstall LightningReview.Extension.ProjectTemplates

rem pack 
del .\src\bin\Release\*.nupkg
dotnet pack src -o ./src/bin/Release

rem install templates
dotnet new --install ./src/bin/Release/*.nupkg

pause