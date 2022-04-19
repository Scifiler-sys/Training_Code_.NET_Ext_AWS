using System;

//Namespaces are a great way to group c# files together
namespace CarFunction 
{
    //This is how you create a class by using the class keyword
    //Public is just there to make the class available for everyone
    public class Car
    {
        //Each class has multiple class memebers you can place inside a class that does something specific

        //This is a field
        //It is used to store information or define the current state of the object when you first make it
        //It is a good practice to keep every field you make in a class private
        //private means that only the class itself can use it
        //string means that the variable will only hold sentences or words
        private string _color;
        private string _owner;

        //int means that the variable will only hold whole numbers
        private int _fuel;
        private int _gallonPerMile;

        //This is a constructor
        //It is a method that will execute whenever you create an object from this class
        public Car()
        {
            Console.WriteLine("Creating a Car!");

            //It is good practice to set the current value of fields inside a constructor
            //So we essentially made a way that every Car we make will start as Red
            _color = "Red";
            _owner = "No Owner";
            _fuel = 100;
            _gallonPerMile = 1;
         }

        //This is a Property
        //Allows flexibility on reading, writing, or computing a field
        //They are essentially used to edit fields
        //This is a basic property that will write and read a field
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        //This is a property that will only read a field anywhere but will only write a field only in the class itself
        public string Owner
        {
            get{ return _owner; }

            //private can also be used to make it only available to the class itself
            private set { _owner = value; }
        }
        
        public int Fuel
        {
            //Will make it write only field
            private get { return _fuel; }
            set {_fuel = value; }
        }

        public int GallonPerMile
        {
            get {return _gallonPerMile; }
            set {_gallonPerMile = value; }
        }

        //A method will run multiple lines of code to do some sort of a function/behavior
        //void means the method will return nothing
        //We can change that to any datatype or class 
        public double TotalDistancePerFullFuel()
        {
            //Displays the current state of Car object
            Console.WriteLine("Current Fuel:" + Fuel);
            Console.WriteLine($"GallonPerMile: {_gallonPerMile}");
            
            //Return keyword is what the method will return
            return (double)Fuel/GallonPerMile;
        }

        //Methods can also have parameters
        //They are implemented by adding in datatypes inside of the parenthesis
        //The comma is used if a method needs more than 1 parameter
        //In this case we have a method with two parameters that take in integers (so numbers)
        //Note: parameters are a great way (if not the best way) to pass additional data to a method that it needs to use
        public void ParameterDemo(int x, int y)
        {
            Console.WriteLine($"The sum: {x+y}"); 
        }

        //A special type of method that you inherit from the System.Object
        //This method is invoked whenever you need a string representation of the object
        //By default, it just gives the current namespace of the object
        // public override string ToString()
        // {
        //     return $"Color: {Color}\nPrice: {Price}";
        // }
        
    }

    //Documentation
    //Class members in C#
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members
    //Classes and Objects
    //https://www.w3schools.com/cs/cs_classes.php
}
