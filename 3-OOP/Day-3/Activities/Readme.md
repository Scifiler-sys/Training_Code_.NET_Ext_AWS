# Group Activity

## Adding Logging functionality to your program
* Make sure you have a functional AddCustomer first
* We will log information based on what the user is doing in our application
    * There are other ways to log information but that will be the premise we will start with
* You can have logger on the different projects if you want, but you can strictly just have logging in the UI project
1. Make sure you have installed the proper packages needed to accomplish this specifically inside of the UI project
```
dotnet add package Serilog
dotnet add package Serilog.Sinks.File
```
* You can confirm if you installed the right packages by looking at the .csproj file
2. Update your program.cs file with creating and configuring the logger
    * Code should look similar to what I did on the demo
    * Make sure to use Serilog namespace for intellisense to detect and work properly
3. Start logging!
    * Log information to where it makes sense to do so
    * What is currently being displayed
    * What is the function the user is trying to do
    * Any potential warning/validation displayed to the user due to the user putting in the wrong thing
    * etc.
