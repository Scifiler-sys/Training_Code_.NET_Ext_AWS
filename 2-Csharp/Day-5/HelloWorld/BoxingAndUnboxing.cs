using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class BoxingAndUnboxing
    {
        public static void BoxingMainMethod()
        {
            Console.WriteLine("==== Boxing and Unboxing ====");
            
            //Value type
            //You get the value directly
            int num = 123;

            //Boxing example
            //When a value type gets casted into an object
            //What happens is that the value is wrapped to give it a reference type behavior
            //No other syntax is needed
            //It is implicit conversion
            object obj = num;
            Console.WriteLine(obj);

            //Unboxing example
            //When you extract the value type from the object and just get the value directly instead
            //A syntax is needed (dataType)Object
            //It is explicit converion
            int num2 = (int)obj;
            Console.WriteLine(num2);

            //Implicit Casting
            int num3 = 123;
            double dec = num3; //No special syntax needed

            //Explicity Casting
            double dec2 = 123.0;
            int num4 = (int)dec2; //Must add syntax and you have a potential lost of memory/information
        }

        //Documentation
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
    }
}