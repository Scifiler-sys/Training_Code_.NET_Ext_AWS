# S.O.L.I.D Principles
* They are five design principles intended to make software designs more understandable, flexible, and maintainable
    * Kinda like the OOP pillars, but it is just rules to follow to write better code
## Single Responsible Principle
* A class should have one and only one reason to change
* If one class has more responsibility, just segregate them into many classes 
* Ex: Software Engineer class should just manage anything related to creating a program and shouldn't also have the responsiblity to manage financial forms. Instead, segragate the two class and create a Accountant class that will hold that responsiblity
## Open/Closed Principle
* A class should be open for extensions but closed for modification
* It just means you can add new funcitonality without changing existing code
* A great way to do this is uing interfaces
    * Such as us using dependency injection with interfaces
    * Or using Imenu interface and all our code we wrote in program.cs works just fine with any of our new C# classes
## Liskov Substitution Principle
* Derived class should be substitutable for their base class implementation
* It just means derived classes should not behave in such a way that it will not cause problems when used instead of a base class
* One way to avoid breaking is using the base class implementation as well as your derived class implementation
## Interface Segregation Principle
* You should not be forced to implement methods that you don't need in an interface
* Just segregate the interface into multiple interfaces
## Dependency Inversion Principle
* High and low level modules should depend on abstractions but not on each other
* If a class uses the design and implementaiton of another class, it raises the risk that change one class could break the other class
* To fix, we must both let them depend on abstractions 

# Design Pattern
* They are reusable solution that will solve the problems that occurs pretty frequently while coding
* Essentially, some people saw that problem keeps happening across multiple coders and decided to standardize a solution every time you come across to that problem to make your life easier
* They are some of the best practice a programmer can do to solve common problems while designing your application
## Singleton Pattern
* This pattern revolves around creating one concurrent object of a class (So only one object exists while the application runs)
* This singleton class provides a way to let other classes have direct access to the single object
* Just think of a universal object that gives access to everyone
### Advantage
* Provides a global point of access from multiple classes
* It is easy to maintain since there is only one instance of that class
### Disadvantage 
* Very difficult to unit testing since it has global access
* Definitely do not put any security sensitive information in a singleton
