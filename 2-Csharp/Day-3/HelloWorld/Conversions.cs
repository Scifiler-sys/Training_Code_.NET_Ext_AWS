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

            Console.WriteLine("=Implicit=");
            double doubleNum = x;
            Console.WriteLine(doubleNum);

            Console.WriteLine("=Explicit=");
            int intNum = (int)y;
            Console.WriteLine(intNum);

            //More Explicit Conversions
            string stringVar = x.ToString();
            Console.WriteLine(stringVar);

            double doubleNum2 = Convert.ToDouble(i);
            Console.WriteLine(doubleNum2);
        }

        //Documentation
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
    }
}