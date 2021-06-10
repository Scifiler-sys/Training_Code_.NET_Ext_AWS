using System;
using HouseFunction;
/*
    Naming Conventions in C#:
    - We use PascalCase for the most part and that means naming artifacts as EveryFirstLetterIsCapitalized.
    - We use camelCase for naming fields and that means naming artifacts as onlyTheFirstWordIsNotCapitalized.
    - As you can see, the auto-generated class has PascalCase for most things.
*/

namespace HelloWorld
{
    class Program
    {
        //We can use underscores for private fields to reference them easier.
        private static string _first = "Hello ";
        private string _last = "World!";

        /*
            - Main method is the first method that will be called/run. (The compiler will look for this method)
            - The static means, I don't have to instantiate the program class to use that method
            - Void, the method will not return anything.
            - string[] args, method uses 
        */
        static void Main(string[] args)
        {
            Console.WriteLine("====Hello World====");
            // Console.WriteLine(Program._first + Program._last); //First thing you write

            Program prgm = new Program();

            Console.WriteLine(Program._first + prgm._last); //Second thing you write when talking about static
            Console.WriteLine(Program.Hello()); //For void method

            // Console.WriteLine(args[0] + args[1]); //To test string[] args parameter

            Console.WriteLine("====Classes and Objects====");
            House house1 = new House(); //The new keyword tells the compiler to make a new object
            Console.WriteLine(house1.Color);
            House house2 = new House();
            house2.Color = "Blue";
            Console.WriteLine(house2.Color);
            // house2.Price = 5000;
            Console.WriteLine(house2.Price);
            House house3 = new House(10000);
            Console.WriteLine(house3.Price);

            Console.WriteLine("====Collections Tests====");
            Collections collectObj = new Collections();
            collectObj.CollectionsMain();

            OOP.OOPMain();

            BoxingAndUnboxing.BoxingMainMethod();
        }

        static string Hello() //Method we will use
        {
            return "Hello World! Method";
        }
    }
}
