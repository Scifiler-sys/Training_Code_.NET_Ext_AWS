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
    }
}
