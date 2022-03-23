@echo off
set /p version="Enter Version Number to Build With: "

@echo on
dotnet pack ".\TomLonghurst.ILogger.UnitTest.Verifier.Moq\TomLonghurst.ILogger.UnitTest.Verifier.Moq.csproj"  --configuration Release /p:Version=%version%

pause