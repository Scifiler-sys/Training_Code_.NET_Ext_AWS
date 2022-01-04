# Group Activity

## Add more function to your Menu console app
1. Create a new C# file inside your menu project called Serialize
2. Create a Serialize class that will store a collection into a JSON file
3. Add any class members (methods, constructors, properties, fields, etc.) to Data class that you think will be useful to accomplish the following functions. 
3. Update function to Menu to add elements to a collection to also store in a JSON file
4. Update function to Menu to display all the current elements from the JSON file
    * Closing the program should still display any current elements from the JSON file
5. Update function to Menu to remove certain elements from the JSON file
6. Add function to Menu to search for a certain element in a JSON file
    * Look into C# documentation of what methods are available for you in the collection that you are using that might help you find certain elements
    * You can also just create your own coding logic to find certain elements in a collection
    * If no element exist, be sure to tell the user that the element was not found.
## Useful Hints
* Be sure to take into account that File.WriteAllText() method will overwrite anything inside of the JSON file
    * A good possible workflow would be to convert the JSON into a collection first then add the new element in then convert the collection back into a JSON then save it into a JSON file (in this way anything overwritten will not be lost)
* You already have most of the functionality if you completed it from last group activity so just think about when to convert it to JSON string and when to save it into a JSON file
* Be sure to have exception handling in your code for possible exceptions the user might run into