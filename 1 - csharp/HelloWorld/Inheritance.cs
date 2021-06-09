using System;

namespace HelloWorld
{
    public class Animal
    {
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
        public string OwnerName { get; set; }

        //Example of Method Overriding
        //Must state override (non-access modifier) that this method overrides a method in the base class
        public override void Speak()
        {
            Console.WriteLine("Bark");
        }
        //Example of Method Overloading
        public void Speak(string p_speak)
        {
            Console.WriteLine(p_speak);
        }
    }
}

