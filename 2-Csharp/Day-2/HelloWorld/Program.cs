using CarFunction; //We need to import the namespace of that class to even start using it anywhere else
using MenuFunction;

// See https://aka.ms/new-console-template for more information

//Program.cs is the implicity generated main method that will become the entry point of the program
//As of C# 9.0, they decided to make top-level statements which basically mean you can write less code to do the same operation
//Since they decided to hide things from you by implicitly doing it itself, it gets a bit confusing what's really happening at the back

//One important thing you just need to know is that the main method is the entry point of your program
Console.WriteLine("Hello, World!");

//To use any classes we make, we have to make an object out of that class
//Same thing with blueprints, to use any blueprints we make, we have to make the actual object itself

Console.WriteLine("===Classes and Objects===");
//This is how you create an object out of a class
//Syntax - [NameOfClass] [NameOfObject] = new [NameOfClass]
Car car1 = new Car();

//To access the class members of a class, you must add a "." after the object name
Console.WriteLine(car1.Color); //This is to get the property
car1.Color = "Blue"; //This is to set the property
Console.WriteLine(car1.Color);

// car1.Owner = "Stephen"; Will not work since Owner is read only property

//Accessing methods of a class
Console.WriteLine(car1.TotalDistancePerFullFuel() + " Miles");

car1.GallonPerMile = 3;

Console.WriteLine(car1.TotalDistancePerFullFuel() + " Miles");

//Like with blueprints, you can create more objects from a class
Car car2 = new Car();
Car car3 = new Car();
//However, they will all share the same current state and behavior because you just made them!
Console.WriteLine(car2.Color);
Console.WriteLine(car3.Color);

//===Menu Demo===
Menu m1 = new Menu();
m1.Start();

//Testing static method
Menu.Sum(5, 10);