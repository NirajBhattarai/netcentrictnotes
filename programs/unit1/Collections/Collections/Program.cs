using System;
using System.Collections;
using System.Collections.Generic;

class CollectionsDemo
{
    static void Main(string[] args)
    {
        // Generic Collections

        // List<T>
        List<int> intList = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("Generic List:");
        foreach (int i in intList)
        {
            Console.WriteLine(i);
        }

        // Dictionary<TKey, TValue>
        Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };
        Console.WriteLine("\nGeneric Dictionary:");
        foreach (KeyValuePair<string, int> kvp in dictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        // HashSet<T>
        HashSet<string> hashSet = new HashSet<string> { "apple", "banana", "orange" };
        Console.WriteLine("\nGeneric HashSet:");
        foreach (string item in hashSet)
        {
            Console.WriteLine(item);
        }

        // SortedList<TKey, TValue>
        SortedList<string, int> sortedList = new SortedList<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };
        Console.WriteLine("\nGeneric SortedList:");
        foreach (KeyValuePair<string, int> kvp in sortedList)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        // Queue<T>
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");
        Console.WriteLine("\nGeneric Queue:");
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }

        // Stack<T>
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine("\nGeneric Stack:");
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }

        // Non-Generic Collections

        // ArrayList
        ArrayList arrayList = new ArrayList { 1, "two", 3.0 };
        Console.WriteLine("\nNon-Generic ArrayList:");
        foreach (object item in arrayList)
        {
            Console.WriteLine(item);
        }

        // Hashtable
        Hashtable hashtable = new Hashtable
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };
        Console.WriteLine("\nNon-Generic Hashtable:");
        foreach (DictionaryEntry entry in hashtable)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }

        // Queue (non-generic)
        Queue nonGenericQueue = new Queue();
        nonGenericQueue.Enqueue("First");
        nonGenericQueue.Enqueue("Second");
        nonGenericQueue.Enqueue("Third");
        Console.WriteLine("\nNon-Generic Queue:");
        while (nonGenericQueue.Count > 0)
        {
            Console.WriteLine(nonGenericQueue.Dequeue());
        }

        // Stack (non-generic)
        Stack nonGenericStack = new Stack();
        nonGenericStack.Push(1);
        nonGenericStack.Push(2);
        nonGenericStack.Push(3);
        Console.WriteLine("\nNon-Generic Stack:");
        while (nonGenericStack.Count > 0)
        {
            Console.WriteLine(nonGenericStack.Pop());

        }
    }
}
