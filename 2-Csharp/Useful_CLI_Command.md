# What is CLI?
* It stands for Command Line Interface.
* It is a way for us to instruct the computer to do something. It will accept a certain phrase and depending on that phrase it will do certain actions.

# .Net 5 CLI Commands
* dotnet new [typeOfProject] -o [folderName] - Most commonly used to create projects but can also be used to create other templates.
    - Ex: This command will create a console project in a folder named HelloWorld
    ``` 
    dotnet new console -o HelloWorld
    ```
    - [Microsoft Documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new)
* dotnet run - it will run your application
* dotnet add reference - it will add project reference
* dotnet add package - it will add a package