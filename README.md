# StarWars Fleet Management

### Requirements

* Git (for cloning repository)
* ASP.NET Core 2.1 SDK
* Microsoft Visual Studio 2017 Community Edition or higher or VSCode

### Features

* Console Application using .NET Core 2.1
* Unit Tests using MSTest

### Building and executing

Clone repository:
```sh
git clone https://github.com/victormasutani/StarWarsFleetManagement.git
```

Run Console project
```sh
StarWarsFleetManagement\StarWarsFleetManagement.Console
dotnet run
```

### Testing

Unit test API project (from VS 2017 or VSCode)
```sh
StarWarsFleetManagement\StarWarsFleetManagement.Tests
dotnet test
```

### About

Using the API (https://swapi.co), this project receives a input distance in MGLT (mega lights) and calculates all starships amount of stops required to travel this input distance, based on starship MGLT (The Maximum number of Megalights this starship can travel in a standard hour) and consumables (The maximum length of time that this starship can provide consumables for its entire crew without having to resupply).

The calculation used for each starship was:

inputedMGLT / (totalHoursOfConsumables * starshipMGLT)

If any variable is missing or incorrect it should display "unknown"

### License
Free

