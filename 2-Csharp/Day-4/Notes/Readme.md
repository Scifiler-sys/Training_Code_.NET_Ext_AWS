# Serialization
* The process of converting your objects into a stream of bytes (101001010) or a JSON file or an XML file for storage or transfer
* Helpful to store information that you want to persist even if you close down your program since it will be stored in your harddrive
    * Later in the program, we will use JSON to also send information between multiple computers/servers
* Two popular types of way to serialize information:
    1. JSON - JavaScript Object Notation (most popular one and easiest to understand)
    2.2 XML - eXtensible Markup Language (uses tags to define what the information is being sent)

# Exceptions
* An exception is an event that occurs during the execution of a program that distrupts the normal flow of instructions
    * Horrible to encounter when presenting your program (When it is expected to work perfectly fine)
    * Great when trying to find bugs in your program
* They are not Errors!
## Errors
* A serious problem that for the most part cannot be handled by the developer
    * They are fatal to the program at runtime
    * Ex: A stack overflow error and that usually occurs when your computer has run out of memory to store information
* 3 types of errors
    * Usage error - error in your program logic and can be solve by modifying/restructuring your code
    * Program Error - run-time error that cannot be avoided even with a bug-free code (Ex: Your SDK is corrupt and can't compile or translate it to machine code properly)
    * System Failures - run-time error that cannot be handled programmatically in a meaninful way (Ex: your ram hardware is faulty)
## Exception Handling
* Using a try-catch block and optionally finally block
* If you know the block of code you will run will have a risk of throwing an exception, you should put it in the try block
* The catch block will then "catch" that exception and will run instead its block of code
* Optionally, you can add a finally block that will run regardless if your code throws an exception or not
    * Mostly used to clean up any resources you used in the try blcok
## Throwing Exception
* You can throw an exception yourself in your code by using the throw keyword
* Useful for enforcing certain rules/logic in your program
## Exception Heirarchy
* Certain exceptions are more specific than other exceptions
* General rule is the most specific exception should be the very first catch block and the least specific exception is at the very last catch block
    * Why? Well if you made the least specific the first catch block then it will always run if any exception is thrown making your other catch blocks useless
