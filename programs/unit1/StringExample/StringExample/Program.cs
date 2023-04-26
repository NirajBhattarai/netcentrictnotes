using System;

class Program
{
    static void Main(string[] args)
    {
        // Concatenation
        string firstName = "John";
        string lastName = "Doe";
        string fullName = firstName + " " + lastName;
        Console.WriteLine(fullName); // Output: John Doe

        // Length
        string message = "Hello World";
        int length = message.Length;
        Console.WriteLine(length); // Output: 11

        // Substring
        string hello = message.Substring(0, 5);
        Console.WriteLine(hello); // Output: Hello

        // IndexOf
        int index = message.IndexOf("World");
        Console.WriteLine(index); // Output: 6

        // Replace
        string newMessage = message.Replace("Hello", "Hi");
        Console.WriteLine(newMessage); // Output: Hi World

        // Split
        string data = "1,2,3,4,5";
        string[] parts = data.Split(',');
        foreach (string part in parts)
        {
            Console.WriteLine(part); // Output: 1 2 3 4 5
        }
    }
}

