# Employee List
> An employee contact form and table with full CRUD functionality using Vue.js and Asp.Net Core

## Scope
This is a project to demonstrate extending existing conecepts into larger projects. It is an employee contact form for data entry based off of Tania Rascia's Vue.js tutorial found [here](https://www.taniarascia.com/getting-started-with-vue/).

## Development Stack
The application was built using the following:
- ASP.Net Core 2.2
- Vue.js

## Setup
In order to test/use this application, you will need the following:
- Asp.Net Core 2.0 SDK, prefereably 2.2.1
- Node.js version 8 or higher
- The Vue CLI

## Installation
Grab the repository either by downloading the zip file or clone the project:
```sh
~$ git clone https://github.com/johnmcraig/employee-list
```
After cloning or unzipping the files, navigate to the directory containing the solution file:
```sh
~$ cd src/EmployeeList/
```
In either order, navigate to the client or api/server side files and install their dependecies. Once again, you will need Node.js and `npm` installed along with the .Net Core 2.2 SDK.

For client side dependecies:
```sh
~$ cd src/EmployeeList/client
~$ npm install
```
Make sure the `@vue/cli` is installed as well:
```sh
~$ npm install -g @vue/cli
```

For server side code, build and restore dependecies and NuGet packages:
```sh
~$ cd src/EmployeeList/server/
~$ dotnet restore
```

## Running the Environment
To run a local environment on the client side:
Use `npm` script commands in a terminal/command box while in the `../client` directory:
```sh
~$ npm run watch
```
This outputs a minified JavaScript file in the `wwwroot/dist` directory of the API.

To run a local environment on the server side:
Use the `dotnet <COMMAND> <OPTIONS>` tool to run it in a terminal or use Visual Studio to run it with `CTL` + `F5`

Navigate to localhost:5001 in a browser to see the current build running.

## TODO
- Add Authorization and Login.
- Enable searching by Employee name.

## Known Issues and Bugs
- The delete action in the controller class has an issue with binding the model with the repository delete method, so it is using the context class instead.