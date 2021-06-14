using System;

namespace HelloWorld
{
    public class Animal
    {
        public Animal()
        { }
        public Animal(string p_name, string p_color)
        {
            Name = p_name;
            Color = p_color;
        }
        public string Name { get; set; }
        public string Color { get; set; }

        //Must state virtual (non-access modifier) that this method will be overriden
        public virtual void Speak()
        {
            Console.WriteLine("Speak");
        }
    }

    public class Dog : Animal
    {
        public Dog()
        { }
        //This is an example of Constructor Overloading
        public Dog(string p_OwnerName) 
        {
            OwnerName = p_OwnerName;
        }

        public Dog(string p_name, string p_color, string p_OwnerName) : base(p_name, p_color)
        { 
            OwnerName = p_OwnerName;
        }
        
        public string OwnerName { get; set; }

        //Example of Method Overriding
        //Must state override (non-access modifier) that this method overrides a method in the base class
        public override void Speak()
        {
            base.Speak(); //Will call the base class method (put during Liskov substitution principle)
            Console.WriteLine("Bark");
        }
        //Example of Method Overloading
        public void Speak(string p_speak)
        {
            Console.WriteLine(p_speak);
        }
    }

    public class OOP
    {
        public static void OOPMain()
        {
            Console.WriteLine("====OOP Tests====");

            //Created new dog object
            Dog dog1 = new Dog()
            {
                OwnerName = "Stephen"
            };

            //Test the properties of dog object
            Console.WriteLine(dog1.OwnerName);
            dog1.Speak();
            dog1.Speak("Bark2");
        }
    }
}

