# CUNA Backend Coding Challenge

# Architecture
This solution is built using .NET Core. It contains two projects; WebAPI and WebAPI.UnitTests.

The WebAPI project uses ASP.NET Core WebAPI to run the REST APIs. The app was written to run in an Azure App Service. It stores it's data in an instance of Azure CosmosDB.

All the unit tests were written with xunit and I used NCrunch to continually run them while I was developing the solution. As a result, when everything runs, there should be a high code coverage number. The database being used for the unit tests runs in memory.

This solution uses the following NuGet packages:
- coverlet.collector
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Cosmos
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.NET.Test.Sdk
- Newtonsoft.Json
- Swashbuckle.AspNetCore
- xunit
- xunit.runner.visualstudio

# URL
I've included Swagger with my implementation to make it easier to test out. You can get to it here: https://cuna-backend-coding-challenge.azurewebsites.net/swagger/index.html

# CI/CD
I built a few CI/CD pipelines using GitHub Actions to make it easy to run tests and deploy the solution.

- push-to-develop - This pipeline is triggered by any push to the develop branch. It will build the WebAPI and WebAPI.UnitTests projects and run the tests in WebAPI.UnitTests.
![push-to-develop](https://github.com/tcardella/cuna-backend-coding-challenge/workflows/push-to-develop/badge.svg)

- pull-request-to-master - This pipeline is triggered anytime someone creates a pull request against master. It will build both projects and run the tests. If the code does not build or test-out, the pull-request cannot be completed and merged.
![pull-request-to-master](https://github.com/tcardella/cuna-backend-coding-challenge/workflows/pull-request-to-master/badge.svg)

- deploy-from-master - This pipeline is triggered whenever something is pushed to the master branch. It not only builds the projects, runs the tests, it also deploys the solution to an existing Azure App Service.
![deploy-from-master](https://github.com/tcardella/cuna-backend-coding-challenge/workflows/deploy-from-master/badge.svg)

# Build Instructions
Building this solution is pretty easy. You'll just need to clone the repo to your local machine, open a command prompt, navigate to the solution directory, type `dotnet build`, and hit Enter.

Running the solution is easy as well. Go to your command prompt, navigate to the solution directory, type `dotnet run`, and hit Enter. This should build the solution if it has not already been built and then it will open your default web browser to the Swagger interface.

To run the unit tests, you'll need to open a command prompt, navigate to the solution directory, type `dotnet test`, and hit Enter.

# Issues
There are some known issues with this solution.
1. The url for the Third Party Service I was given does not appear to work. It just returns 405 everytime.
2. Because of #1, I could not run my solution completely. I went through and tried to get things working as best I could. I do have unit tests covering the REST APIs so if #1 is resolved, then #2 should not be that hard to test and get working.
