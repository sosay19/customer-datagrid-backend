@echo off

:: Print the current working directory
echo Current directory: %cd%

:: Check .NET version
echo Checking .NET version...
dotnet --version

:: Build the project
echo Building the project...
dotnet build

echo CI Pipeline executed successfully!
