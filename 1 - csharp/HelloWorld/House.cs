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
        {
            Price = 6000;
        }

        public House(int p_price)
        {
            Price = p_price;
        }
        //You can have multiple constrcutors with different parameters (Called constructor overloading)
        public House(int p_price, string p_color) : this(p_price)
        {
            _color = p_color;
        }

        //This is a property
        public string Color
        {
            get{return _color;}
            set{_color = value;}
        }

        public int Price { get; set; }

        public static void HouseMain()
        {
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
            
        }
    }
}
