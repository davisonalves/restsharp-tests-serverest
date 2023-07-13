# API Testing with Restsharp
This is an example of how to automate API tests using C#.

## Installation and Execution
### Prerequisites

- Docker
- .NET 6

### Running the API in your local environment
[![Badge ServeRest](https://img.shields.io/badge/API-ServeRest-green)](https://github.com/ServeRest/ServeRest/)
```
docker run --rm -p 3000:3000 paulogoncalvesbh/serverest:latest
```

### Running tests via command line

Execute all tests via the command line with the following command:
```
dotnet test -s .\app.runsettings
```

or

Filter the tests you want to execute via the command line using the following commands:

| Category           | Command															|
|--------------------|------------------------------------------------------------------|
| smoke				 | `dotnet test --filter Category=smoke -s .\app.runsettings`		|
| contract tests     | `dotnet test --filter Category=contract -s .\app.runsettings`	|
| functional tests   | `dotnet test --filter Category=functional -s .\app.runsettings`	|

## Project Structure
```
.
├───App
│   ├───Data
│   │   ├───Common
│   │   ├───Factory
│   │   └───Schema
│   ├───Helper
│   └───Model
│       ├───Login
│       ├───Product
│       └───User
|
└───Test
    ├───Login 
    ├───Product 
    └───User
```

## Technologies Used

- [Restsharp](https://restsharp.dev/) - To make API requests
- [Nunit](https://nunit.org/) - For writing and executing tests
- [Bogus](https://github.com/bchavez/Bogus) - To generate random data
- [NJsonSchema](https://github.com/RicoSuter/NJsonSchema) - To load and validate JSON schemas

> Note: The idea behind this architecture is to associate each automated test with a test case in Azure Test Plan and ultimately integrate it into a pipeline. This way, test execution reports with graphs and other information will be generated and stored in Azure.