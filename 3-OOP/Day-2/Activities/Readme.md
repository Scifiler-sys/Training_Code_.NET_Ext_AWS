# Group Activity
* Open up the Store App SDD.pdf for your P0 requirements
* Start thinking about what theme you want to follow through for the store app
* :exclamation:**Focus on finishing the functionalities first**:exclamation: before adding any extra features you will like to implement on your store app.

## Complete Adding Customer function
* Must have Adding Customer menu page completed before starting this step
* Update BL and DL project to also save the customer to a database (A JSON file)
1. Start with the DL project
2. Create a repository interface and start listing potential methods you might need
    * Be sure to add XML documentation
3. Create a repository that inherits the interface and add the actual implementation detail to accomplish the task
    * Just finish one method at a time and test if the method is working
4. Go to the BL project
5. Same workflow, create an interface and a class that inherits the interface
6. Don't forget to include dependency injection in the constructor of class
    * It makes it so when we update the DL project in the future, you don't have to change/refactor any of your other projects but just the DL project
7. If needed, do further data processing within the method
8. Go to the UI project
9. Add dependency injection on the C# file responsible for displaying the add customer UI
10. Update the UI to now store the customer information to the database

### Things to consider
* Data layer should be the only project that can exclusively manipulate our database
* Business layer might do further processing or validation on the data it obtains from the Data Layer
* Be sure to implement Dependency Injection right
    * Will be extremely useful when we go around and updating our projects further
* Don't forget that to reference other C# files from a different project you need to use a CLI command
``dotnet add reference (filepath)``
* Proper documentation with XML comments
