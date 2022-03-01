# JavaScript
* Best way to make your website dynamically changed
* It is both a functional language and object-oriented programming language (ever since ES6)
    * Functional language just means that it uses a lot of functions and you can also use them as variables, parameters inside of other functions and it makes things look... very complicated
    * You can think of functions as methods in C# just with a different name and doesn't need a class attached to it to make one
* Key difference with C# is that it is **loosely typed**
    * Meaning every variable you create can hold any datatype and will have no issues switching between datatypes (Remember cannot implicity convert blah blah exception on C#? That's gone in JavaScript)
* Interesting enough JavaScript is both compiled and interpreted
    * It used to be just interpreted (like SQL) but with introduction to more modern tools that uses JavaScript they improved it to also be compiled
    * Essentially, if a function keeps getting called multiple times, it will compile that code into an optimized native machine code to be more efficient 
* We are currently in EcmaScript 6 version
    * It introduced many wonderful things but for the most part confused a ton of people who use JS often in the past since this is when classes are introduced.

# Datatypes
* QC might ask a list of datatypes from JS so here are a couple most used ones
* Numbers
* Boolean
* Strings
* Objects
* Null - Lack of value meaning this variable doesn't have any information at the moment
* Undefined - no value was set meaning you just created a variable and didn't set it with any value

# Prototype
* It is like a field in C# in a form of a key-value pair
* Every function (and other things) have prototypes and you can add prototypes as well
## Prototypal Inheritance
* The technical name that says you can inherit other prototypes so you have code re-usability

# Classes
* As you know, templates for creating objects
* Didn't use to exist which made things weird and divided some communities in JS
    * Essentially some people say to never use it because it's inefficient or error prone
    * Some people say to use it because it makes looking at your code easier to read (you should see example of how JS used to implement class-like things using just functions (spoiler alert: it looks gross))
* Has most of the OOP pillars we discussed and implements them easily except abstraction

# JS HTML DOM
* Allows JavaScript to specifically pick certain elements in the HTML and change/manipulate them somehow based on whatever function you created
* This is what makes JS a powerful tool to making your html page dynamically change based on whatever the user is doing