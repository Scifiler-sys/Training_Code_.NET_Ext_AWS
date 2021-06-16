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
        private string _last = "World!"; //Make this static first

        /*
            - Main method is the first method that will be called/run. (The compiler will look for this method)
            - The static means, I don't have to instantiate the program class to use that method
            - Void, the method will not return anything.
            - string[] args, method uses 
        */
        static void Main(string[] args)
        {
            Console.WriteLine("====Hello World====");
            // Console.WriteLine(Program._first + Program._last); //When both fields are static

            //This is how you instantiate an object from a class
            Program prgm = new Program();

            //since _last field is no longer static, we need to instantiate an object to get that field's value
            Console.WriteLine(Program._first + prgm._last); 
            //if we write a data type instead of void on a method, the method returns that data type
            Console.WriteLine(Program.Hello());

            //string[] args is a way for you to pass data when running your console
            // Console.WriteLine(args[0] + args[1]); //To test string[] args parameter
            
            //Testing House
            House.HouseMain();

            //Testing Collections
            Collections collectObj = new Collections();
            collectObj.CollectionsMain();

            //Testing OOP Pillars
            OOP.OOPMain();
        }

        static string Hello() //Method we will use
        {
            return "Hello World! Method";
        }
    }
}
