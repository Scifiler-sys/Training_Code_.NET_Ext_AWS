using System;
using System.Linq;

namespace HelloWorld
{
    public class LINQ
    {
        public static void LINQMain()
        {
            //A data source
            int[] numbers = new int[5]{0,1,2,3,4};

            //Query that will select only even numbers
            //Example of Query syntax
            var queryResult = (from num in numbers
                                where num%2 == 0
                                select num);

            //Example of Method syntax
            //Where method is similarish to the where statement in SQL
            var queryMethodResult = numbers.Where(num => num%2 == 0);

            //Execution
            foreach (var item in queryResult)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Method Syntax way");
            foreach (var item in queryMethodResult)
            {
                Console.WriteLine(item);
            }
                            
        }
    }
}