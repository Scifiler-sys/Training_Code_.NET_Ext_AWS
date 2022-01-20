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

# Conversion
* C# is statically typed at compiled time. Meaning after a variable is declared, it cannot be declared again.
* However, it is possible to change the variable type
## Implicit Conversion
* Generally, it is when you can convert the type without any data loss
* Mostly used with numerical datatypes
* No special syntax needed to write and compiler will do it for you
* Ex: converting an int into a double
## Explicit Conversion
* If there is a risk of losing information, you must perform a **Cast**
* Special syntax is needed to write to tell the compiler to do it anyway
* Casting is denoted with (datatype)
* Convert class is useful for converting a string datatype into another datatype
