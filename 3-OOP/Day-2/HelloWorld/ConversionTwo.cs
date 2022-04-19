namespace ConvFunction
{
    public class Car
    {
        public string Owner { get; set; }
        public int Fuel { get; set; }

        //User-defined conversion
        //Allows us to create a class to be able to convert from some other datatype
        //The parameter is what will determine what datatype will be converted from
        public static implicit operator Car(string p_owner)
        {
            //We must return a car object
            return new Car()
            {
                Owner = p_owner
            };
        }

        public static explicit operator Car(int p_fuel)
        {
            return new Car()
            {
                Fuel = p_fuel
            };
        }
    }

    public class ConversionTwo
    {
        public static void ConversionMain()
        {
            Console.WriteLine("===User-defined demo===");
            string ownerName = "Stephen";
            int fuel = 100;

            Car car1 = ownerName;
            Console.WriteLine(car1.Owner);

            Car car2 = (Car)fuel;
            Console.WriteLine(car2.Fuel);

            Console.WriteLine("==== Boxing and Unboxing demo====");
            
            //Value type
            //You get the value directly
            int num = 123;

            Console.WriteLine("=Boxing demo=");
            //Boxing example
            //When a value type gets converted into an object
            //What happens is that the value is wrapped to give it a reference type behavior
            //No other syntax is needed
            //It is implicit conversion
            //Fun note - autoboxing is done whenever you do a non-generic collection
            //  - why? because non-generic only stores object so it has to convert it into an object
            object obj = num;
            Console.WriteLine(obj);

            Console.WriteLine("=Unboxing demo=");
            //Unboxing example
            //When you extract the value type from the object and just get the value directly instead
            //A syntax is needed (dataType)Object
            //It is explicit converion
            int num2 = (int)obj;
            Console.WriteLine(num2);
        }
    }
}