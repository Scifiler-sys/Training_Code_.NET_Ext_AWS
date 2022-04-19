namespace MenuFunction
{
    public class Menu
    {
        public Menu()
        { 
            this.Name = "Default";
            this.Repeat = true;
        }

        public string Name { get; set; }
        public bool Repeat { get; set; } //Boolean datatype will either store true or false

        public string Answer { get; set; }
        
        public void Start()
        {
            //Will clear the terminal
            Console.Clear();
            Console.WriteLine("Welcome to C# Coding!");
            Console.WriteLine("What is your name?");

            //Getting user inputD
            this.Name = Console.ReadLine();

            //While loop will do the same as the while loop in shell
            while (this.Repeat)
            {
                Console.WriteLine($"Hello {Name}!, What do you want to do today?");
                Console.WriteLine("Enter 1 for add two numbers");
                Console.WriteLine("Enter 2 for exit");

                this.Answer = Console.ReadLine();

                if (this.Answer == "1")
                {
                    Console.WriteLine("Enter for number 1");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter for number 2");
                    int num2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"The Sum: {num1} + {num2} = {num1+num2}");
                }
                else if (this.Answer == "2")
                {
                    this.Repeat = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input, Please press Enter to try again");
                    Console.ReadLine();
                }
            }
        }

        //Static method will make the method belong to the class itself
        //Meaning, we can just call on the method without creating an object
        //Static also works with variables and make the variables belong to the class itself
        public static void Sum(int a, int b)
        {
            Console.WriteLine($"The Sum: {a} + {b} = {a+b}");
        }
    }
}