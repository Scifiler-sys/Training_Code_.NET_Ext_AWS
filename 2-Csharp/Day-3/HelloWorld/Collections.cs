using System;
using System.Collections;
using System.Collections.Generic;

public class Collections
{
    //Array
    //Used to store a datatype and have fixed sizes
    //Syntax: (datatype)[] (name of variable) = new (datatype)[(size of array)];
    private int[] nums = new int[5];

    //Generic collection##
    //They are collection that store specific datatypes
    //Anything inside <(datatype)> is how we define what it will store

    //List Collection
    //Zero-based index
    //Used to store a datatype and have dynamically changing sizes
    private List<string> strings = new List<string>();

    //HastSet Collection
    //There is no particular order to the elements so not zero-based index (meaning you can't get specific elements unless you use LINQ)
    //You cannot have duplicated elements, everything must be unique
    private HashSet<int> numSet = new HashSet<int>();

    //Dictionary Collection
    //Stores info through key-value pairs
    //There is no particular order
    //You can specify what datatype you want both the key and value to be
    private Dictionary<string, bool> dict = new Dictionary<string, bool>();

    //Non-generic collection
    //They are collection that can store anything
    private ArrayList arrayLists = new ArrayList();

    public void CollectionsMain()
    {
        Console.WriteLine("===Arrays===");
        //Allows us to set what to store in certain position
        //Zero-based index - just means the beginning of the array starts at 0
        nums[0] = 3;
        nums[2] = 2;
        nums[4] = 2;

        //A way to go through a list
        //Foreach will iterate through all of the elements of collections
        //Syntax: (datatype) (name of variable) in (name of array/collection)
        foreach (int element in nums)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("====Collections Tests====");
        Console.WriteLine("=List Demo=");
        //We are adding elements to the strings List (You can show List documentation for the methods)
        strings.Add("First element");
        strings.Add("Second element");
        strings.Add("Third element");

        //for is a more detail way to iterate through the elements of collection
        //sets a variable; some condition to specify to repeat; increment/decrement of a variable
        for (int i = 0; i < strings.Count; i++)
        {
            Console.WriteLine("Current Index: " + i);
            Console.WriteLine(strings[i]);
        }

        int x = 0;
        //Will keep iterating until the boolean expression inside the while loop returns false
        while (x < strings.Count)
        {
            Console.WriteLine(strings[x++]);
        }

        Console.WriteLine("=HashSet Demo=");
        numSet.Add(4);
        numSet.Add(2);
        numSet.Add(0);
        numSet.Add(4); //Will not show 4 twice while iterating through

        foreach (int element in numSet)
        {
            Console.WriteLine(element);
        }

        HashSet<int> numSet2 = new HashSet<int>();
        numSet2.Add(32);
        numSet2.Add(60);

        numSet.UnionWith(numSet2);
        // numSet.ExceptWith(numSet2);

        Console.WriteLine("After UnionWith");
        foreach (int element in numSet)
        {
            Console.WriteLine(element);
        }
        
        Console.WriteLine("=Dictionary Demo=");
        dict.Add("Stephen", true);
        dict.Add("Tom", false);
        dict.Add("Minnie", true);

        Console.WriteLine(dict["Stephen"]);
        Console.WriteLine(dict["Minnie"]);
        Console.WriteLine(dict["Tom"]);

        //You can also iterate through a dictionary but that use case is very specific
        //since for the most part dictionaries are useful to find specific information if you know the key

        //There is also Queue and Stack
        //I'll let you do the research on how to use them in your code
        //Queue - First-in First-out so just think of a line. 
        //First person to fall in line will be the first person to get out of the line
        //Stack - Last-in First-out so just think of a pancake stack
        //The last pancake that is at the very top of the stack will be the first one out of the stack

        Console.WriteLine("=ArrayList Demo=");
        //We can add different types in the ArrayList
        arrayLists.Add("First element");
        arrayLists.Add(2);
        arrayLists.Add(3.5);

        foreach (var element in arrayLists)
        {
            Console.WriteLine(element);
        }

        //Stuff we can't do since it treats every element as an object
        //We can't add two element even if they are numbers
        // int test = arrayLists[1] + 5;
        //We can't use string datatype specific methods and that applies to anything else that have specific methods
        // strings[0].ToUpper(); //Possible to do
        // arrayLists[0].ToUpper(); //Impossible to do
    }

    //Documentation
    //https://www.tutorialsteacher.com/csharp/csharp-collection
}