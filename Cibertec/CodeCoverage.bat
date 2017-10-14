@echo off
SET currentPath=%~dp0
SET testPath=%currentPath%Cibertec.WebApi.Tests
SET targetargs="test -f netcoreapp2.0 -c Release \"%testPath%\Cibertec.WebApi.Tests.csproj\""

opencover.console.exe -target:"dotnet.exe" -targetargs:%targetargs% -mergeoutput -hideskipped:File -output:coverage.xml -oldStyle -filter:"+[Cibertec.*]* -[Cibertec.Repositories.Tests*]* -[Cibertec.WebApi.Tests*]*" -searchdirs:"%testPath%\bin\Release\netcoreapp2.0" -register:user

reportgenerator.exe -reports:coverage.xml -targetdir:coverage -verbosity:Error