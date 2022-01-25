namespace OOPFunction
{
    //Base class
    public class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public Animal()
        {
            Name = "Animal";
            Color = "Indigo";
        }

        public Animal(string p_color)
        {
            Color = p_color;
        }

        //Example of Method Overloading
        //When two or more methods have the same name but different parameters
        //Only works with parameters! Two methods with the same name and different return types will not work
        public virtual void Talk()
        {
            Console.WriteLine("Hello");
        }

        //Does not work!
        // public string Talk()
        // {
        //     return "Hello";
        // }

        public void Talk(string p_talk)
        {
            Console.WriteLine(p_talk);
        }
    }

    /*
    - Inheritance is when most (if you didn't add a non-access modifier) public class members gets passed down to a child class
    - Now our Dog class has the same properties and methods as our Animal class
    - Terminology:
        * base class - it is the parent class which the child class inherits from
        * derived class - it is the child class that inherits from the parent class

    - Constructors are a bit special that they aren't inherited but the default base class constructor
     will run whenever you create a child object
    
    */

    //Derived class
    public class Dog : Animal
    {
        //Example of Method overriding
        //It is when a derived class changes the function of the parent class
        //It NEEDS virtual and override keyword to explicitly tell the compiler we are trying to override this method
        public override void Talk()
        {
            Console.WriteLine("Bark!");
        }
    }

    public class OOP
    {
        public static void OOPMain()
        {
            // Dog dog2 = new Dog("test"); //-- Unable to run even though we have an Animal constructor that has that parameter
            Dog dog1 = new Dog(); //However, when we create a dog, Animal constructor still runs and set our default values
            Console.WriteLine("===Inheritance Demo===");
            Console.WriteLine(dog1.Color);
            Console.WriteLine(dog1.Name);

            Console.WriteLine("===Polymorphism demo===");
            dog1.Talk();
            dog1.Talk("What's up?");
        }
    }
}