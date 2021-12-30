using System;
using System.Collections;
using System.Collections.Generic;

public class Collections
{
    //Generic collection
    List<string> strings = new List<string>();

    //Non-generic collection
    ArrayList arrayLists = new ArrayList();

    public void CollectionsMain()
    {
        Console.WriteLine("====Collections Tests====");
        Console.WriteLine("=List Demo=");
        //We are adding elements to the strings List (You can show List documentation for the methods)
        strings.Add("First element");
        strings.Add("Second element");
        strings.Add("Third element");

        //A way to go through a list
        //Foreach will iterate through all of the elements of collections
        foreach (string element in strings)
        {
            Console.WriteLine(element);
        }

        //for is a more detail way to iterate through the elements of collection
        //You control how to iterate through
        for (int i = 0; i < strings.Count; i++)
        {
            Console.WriteLine("Current Index: " + i);
            Console.WriteLine(strings[i]);
        }

        int x = 0;
        //Will keep iterating until the boolean expression inside the while loop returns false
        while (x< strings.Count)
        {
            Console.WriteLine(strings[x++]);
        }
        
        Console.WriteLine("=ArrayList Demo=");
        //We can add different types in the ArrayList
        arrayLists.Add("First element");
        arrayLists.Add(2);
        arrayLists.Add(3.5);

        foreach (var element in arrayLists)
        {
            Console.WriteLine(element);
        }
    }

    //Documentation
    //https://www.tutorialsteacher.com/csharp/csharp-collection
}