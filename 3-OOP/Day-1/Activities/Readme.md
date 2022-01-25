# Group Activity
* Open up the Store App SDD.pdf for your P0 requirements
* Start thinking about what theme you want to follow through for the store app
* :exclamation:**Focus on finishing the functionalities first**:exclamation: before adding any extra features you will like to implement on your store app.

## Creating basic project structure
1. Create a Model **class library** project
2. Create a UI **console** project
3. Create a BL **class library** project
    * For now, just leave this alone
4. Create a DL **class library** project
    * For now, just leave this alone

## Implement possible models required
* Start creating any number of models you think you will need to accomplish the store app
* the PDF file should give you a starting point of what models you will need
* Think about what model will have a collection of another model like my demo

## Implement a basic UI menus
* Like our previous group activity, start creating a menu interface that will navigate through your store app.
* One big difference from our last group activity is that we are making multiple C# files and each C# file will correspond to a single menu page.
    * Just follow the general rule that every C# file should have only one responsibilty and should only be change for that one responsibility only
    * Ex: Adding a customer must be in a different C# file
* Look at the functionalities required for this project and start thinking of a menu that can accomplish those tasks
* Ex:
    Adding a customer
    - It will need a menu that will take in a couple Console.ReadLine() inputs from the user
    - It will need to save that information into a model
    - It needs proper validation (if one of the fields needs an age to make a customer, it wouldn't make sense if the user can input -30 as their age)
    - It needs proper conversion of datatypes since Console.ReadLine() will always give a string 