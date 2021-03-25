# Create .NET projects with Visual Studio and CLI

![build test created with vs](https://github.com/Arnab-Developer/dotnet-cli/workflows/build%20test%20created%20with%20vs/badge.svg)
![build test created with cli](https://github.com/Arnab-Developer/dotnet-cli/workflows/build%20test%20created%20with%20cli/badge.svg)

There are two ways to create projects in .NET, one is using Visual Studio and another is CLI. In this repo there is a folder named 'CreatedWithVs' in that all the projects are created with Visual Studio 2019 and another folder named 'CreatedWithCli' in that all the projects are created with CLI.

## Solution structure

* Class library
* Web application in MVC
* Unit test for class library
* Unit test for web application

## Tech stack

* .NET 5
* C# 9
* xUnit for unit testing
* Visual Studio 2019
* .NET CLI

## .NET CLI commands

The following commands are used to build the projects in 'CreatedWithCli' folder.

```
mkdir CreatedWithCli

dotnet new sln --name CreatedWithCli

mkdir CreatedWithCli.Lib
cd CreatedWithCli.Lib
dotnet new classlib

cd..

mkdir CreatedWithCli.LibTest
cd CreatedWithCli.LibTest
dotnet new xunit
dotnet add reference ..\CreatedWithCli.Lib\CreatedWithCli.Lib.csproj

cd..

mkdir CreatedWithCli.WebApp
cd CreatedWithCli.WebApp
dotnet new mvc
dotnet add reference ..\CreatedWithCli.Lib\CreatedWithCli.Lib.csproj

cd..

mkdir CreatedWithCli.WebAppTest
cd CreatedWithCli.WebAppTest
dotnet new xunit
dotnet add reference ..\CreatedWithCli.WebApp\CreatedWithCli.WebApp.csproj
dotnet add package Moq

cd..

dotnet sln add CreatedWithCli.Lib\CreatedWithCli.Lib.csproj
dotnet sln add CreatedWithCli.LibTest\CreatedWithCli.LibTest.csproj
dotnet sln add CreatedWithCli.WebApp\CreatedWithCli.WebApp.csproj
dotnet sln add CreatedWithCli.WebAppTest\CreatedWithCli.WebAppTest.csproj

dotnet restore

dotnet build

dotnet test
```

