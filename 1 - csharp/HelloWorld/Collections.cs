using System;
using System.Collections;
using System.Collections.Generic;

public class Collections
{
    //Generic
    List<string> strings = new List<string>();

    //Non-generic
    ArrayList arrayLists = new ArrayList();

    public void CollectionsMain()
    {
        Console.WriteLine("=List Demo=");
        strings.Add("First element");
        strings.Add("Second element");
        strings.Add("Third element");

        //A way to go through a list
        foreach (string element in strings)
        {
            Console.WriteLine(element);
        }

        for (int i = 0; i < strings.Count; i++)
        {
            Console.WriteLine("Current Index: " + i);
            Console.WriteLine(strings[i]);
        }

        int x = 0;
        while (x< strings.Count)
        {
            Console.WriteLine(strings[x++]);
        }
        
        Console.WriteLine("=ArrayList Demo=");
        arrayLists.Add("First element");
        arrayLists.Add(2);
        arrayLists.Add(3.5);

        foreach (var element in arrayLists)
        {
            Console.WriteLine(element);
        }

        
    }
}