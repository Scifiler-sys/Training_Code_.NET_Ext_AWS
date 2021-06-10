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
            object obj = num;
            Console.WriteLine(obj);

            //Unboxing example
            //When you extract the value type from the object and just get the value directly instead
            int num2 = (int)obj;
        }
    }
}