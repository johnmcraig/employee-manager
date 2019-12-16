# Data Entry System

> A data entry form with full CRUD functionality using Angular version 8 for front end UI and Asp.Net Core for a back end web Api.

## Scope

This is a project to demonstrate extending concepts into larger projects. It is an employee contact form for data entry using Vue SPA or Angular SPA front-end.

## Development Stack

The application was built using the following tools & frameworks:

- ASP.Net Core 2.2
- Angular version 8.3
- PostgreSQL Database

## Built-in Endpoint Testing

The project contains built in Api endpoint testing using [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore). This was setup in the `Startup.cs`class in both the Configure services and IConfiguration to be used upon startup.
After launching the project in a local environment, navigate to `https://localhost:5001/swagger` to view the test index page.

## Setup

In order to test/use this application, you will need the following:

- Asp.Net Core 2.0 SDK, preferably 2.2.1
- Node.js version 8 or higher
- The Angular CLI

## Installation

Grab the repository either by downloading the zip file or clone the project:

```sh
~$ git clone https://github.com/johnmcraig/employee-list
```

After cloning or unzipping the files, navigate to the directory containing the solution file:

```sh
~$ cd src/EmployeeList/
```

In either order, navigate to the client or api/server side files and install their dependencies. Once again, you will need Node.js and `npm` installed along with the .Net Core 2.2 SDK.

For client side dependencies:

```sh
~$ cd src/EmployeeList/client
~$ npm install
```

Make sure the `@angular\cli` is installed as well:

```sh
# for Angular
~$ npm install -g @angular/cli @angular/core
```

For server side code, build and restore dependencies and NuGet packages:

```sh
~$ cd src/EmployeeList/server/
~$ dotnet restore
```

## Running the Environment

To run a local environment on the client side:
Use `npm` script commands in a terminal/command box while in the `../client` directory:

```sh
# for Angular client
~$ ng build -options
```

This outputs a minified JavaScript file in the `wwwroot` directory of the API via the `angular.json` scripts.

To run a local environment on the server side:
Use the `dotnet <COMMAND> <OPTIONS>` tool to run it in a terminal or use Visual Studio to run it with `CTL` + `F5`

Navigate to localhost:5001 in a browser to see the current build running.

## TODO

- Add Authorization and Login.
- Enable searching by Employee name.

## Known Issues and Bugs

- ~~The Update action in the controller endpoint class under ApiVersion 2 (i.e. api/v2/endpoint) has an issue with sending successful requests to the server due to AutoMapper not able to bind the `EmployeeDto` to the `EmployeeUpdateDto`, so it is using the context class instead on version 1 under `/v1/...` route.~~ (issue has been fixed)

- No issues found at this time.
