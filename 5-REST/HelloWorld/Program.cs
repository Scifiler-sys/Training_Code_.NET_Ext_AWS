// See https://aka.ms/new-console-template for more information
using AsyncFunction;

Console.WriteLine("Hello, World!");
Asynchronous demo = new Asynchronous();

Console.WriteLine("Starting Dinner");

//This is just setup on how you go about using tasks but for us we just have to make our methods asynchronous by using async keyword and await
//The ASP.NET framework will handle the Task objects effectively and we don't have to do this setup 

//Storing our tasks
Task<string> riceTask = demo.CookingRice();
Task<string> meatTask = demo.CookingMeat();
Task<string> vegTask = demo.CookingVeggies();

//Putting them in a list of tasks
List<Task<string>> dinnerTasks = new List<Task<string>>(){riceTask,meatTask, vegTask};

//Note: this is for executing all the tasks at the same time
//While loop that will keep checking if there are more tasks that are still running
while (dinnerTasks.Count > 0)
{
    //WhenAny() will execute all our tasks in a list and will return the first one that finishes
    Task<string> done = await Task.WhenAny(dinnerTasks);
    Console.WriteLine(done.Result); //We get the result of the finished product
    dinnerTasks.Remove(done); //We remove it from our task list since it is finished
}

Console.WriteLine("Cooking rice and meat together but veggies will cook after meat");

Task<string> meatThenVeg = demo.CookMeatThenVeggies();
Task<string> riceTask2 = demo.CookingRice(); //Because previous task was already completed so we need to make a new one

List<Task<string>> dinnerTask2 = new List<Task<string>>(){riceTask2, meatThenVeg};

while (dinnerTask2.Count > 0)
{
    //WhenAny() will execute all our tasks in a list and will return the first one that finishes
    Task<string> done = await Task.WhenAny(dinnerTask2);
    Console.WriteLine(done.Result); //We get the result of the finished product
    dinnerTask2.Remove(done); //We remove it from our task list since it is finished
}