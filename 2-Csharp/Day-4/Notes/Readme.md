# Arrays
* Used to store a datatype and have fixed sizes
* Zero-based index
    * 0 is the starting position of the array
* Other arrays you can make:
    * Multidimensional arrays - int[,] ex = new int[4,2]; would create
    [ [0, 0],
      [0, 0],
      [0, 0],
      [0, 0] ]
    * Jagged arrays - arrays inside of an array are different sizes
    [ [0, 0, 0], 
      [0, 0],
      [0, 0, 0],
      [0, 0 , 0, 0]
    ]
# Collections
* It is a data structure that can hold many values
* All collection has methods to add, remove, or find items since they all inherit from IEnumerable Interface
* In C#, there are two major types of collections: Generic and Non-generic
## Generic
* They are collections that store specific datatype
* The "T" you see in documentation is where you put what data type that collection will hold
### List
* Zero-based index
* Used to store a datatype and have dynamically changing sizes
* The most generic collection that is like an array but doesn't have a fixed size
### HashSet
* There is no particular order to the elements (Not zero-based index)
    * It is harder to find specific elements unless you use LINQ (that's later on)
* Every element is unique (Cannot have duplicated elements)
* Useful since you can perform set operations on two HashSets
* Example of set operations:
    * UnionWith - Lets you combine two Hashsets
    * ExceptWith - Substracts a Hashset from another Hashset
    * etc.
### Dictionary
* Stores info through key-value pairs
* There is also no particular order
* You can specify what datatype you want both the key and value to be
* Useful if you want to find specific information if you know the key
    * Think about your contacts, to find someone's phone number (Value) you just have to search for the person's name (Key) instead of trying to figure out what position that person might be located in like a List collection or an Array
### Other Generic
* You do the research on those two other collections
* Try using them in your code to understand what they do
* Queue - FIFO
* Stack - LIFO
## Non-Generic
* They are collections that can store multiple datatypes
* You don't give it any datatype
* Since C# is type-safe language how is this possible?
* Every class we made and any datatype in C# implicitly inherits Object class
    * Inheritance will make more sense once we talk about Object-Oriented Pillars
* Basically any datatype we put inside of a non-generic collection will be converted into an Object class rather than the datatype itself which can give a massive drawback
    * Can't add numerical datatypes anymore
    * Can't use specific methods from a class
    * etc.
### ArrayList
* Works the same as a List but it is non-generic version of it

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
