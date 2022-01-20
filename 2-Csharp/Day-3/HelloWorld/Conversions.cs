using System;
using System.Collections.Generic;

namespace ConversionFunction
{
    public class Conversions
    {
        public static void ConversionsMain()
        {
            //General coding terms
            //Implicit - just means something is done automatically (usually the compiler)
            //Explicit - just means you have to write some syntax to do something (usually to tell the compiler to do it)

            Console.WriteLine("==== Conversion Demo ===");
            int x = 10;
            double y = 73.748;
            string i = "19.6";

            //Some implicit conversion can be done with certain datatypes
            //The general rule is if you are going from a datatype to another datatype without losing information
            //then the compiler can do it for you
            Console.WriteLine("=Implicit=");
            double doubleNum = x;
            Console.WriteLine(doubleNum);

            //The general rule is if you are going to lose some sort of information then the compiler won't do it for you
            //for obvious reasons
            Console.WriteLine("=Explicit=");
            int intNum = (int)y; //Notice we have to write (datatype)
            Console.WriteLine(intNum);

            //More Explicit Conversions
            string stringVar = x.ToString(); //Another way to convert
            Console.WriteLine(stringVar);

            double doubleNum2 = Convert.ToDouble(i); //Another way to convert
            Console.WriteLine(doubleNum2);
        }

        //Documentation
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
    }
}