using System;

namespace HouseFunction //Similar to Java packages
{
    public class House
    {
        //This is a field
        // public string _color = "Red"; //Not a good practice to make a field public (they are always private)
        private string _color = "Red";

        //This is a constructor (special method that is called upon when an object is initialize)
        public House()
        { }

        //This is a Property, a class member that allows flexibility on reading, writing, or computing a field
        public string Color
        {
            get{return _color;}
            set{_color = value;}
        }

        public int Price { get; set; }

        //A special type of method that you inherit from the System.Object
        //This method is invoked whenever you need a string representation of the object
        //By default, it just gives the current namespace of the object
        public override string ToString()
        {
            return $"Color: {Color}\nPrice: {Price}";
        }
        public static void HouseMain()
        {
            Console.WriteLine("====Classes and Objects====");
            House house1 = new House(); //The new keyword tells the compiler to make a new object
            Console.WriteLine(house1.Color);
            House house2 = new House();
            house2.Color = "Blue";
            Console.WriteLine(house2.Color);
            house2.Price = 5000;
            Console.WriteLine(house2.Price);
            Console.WriteLine(house2);
        }
    }

    //Documentation
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members
}
