using System;
using System.Collections.Generic;
using System.Linq;

class LambdaExample
{
    static void Main()
    {
        List<int> numbers = new List<int> { 5, 8, 2, 10, 6, 1, 3, 7, 9, 4 };

        // Using a lambda expression to filter even numbers
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Even numbers:");
        PrintNumbers(evenNumbers);

        // Using a lambda expression to sort numbers in descending order
        var sortedNumbers = numbers.OrderByDescending(n => n);
        Console.WriteLine("Numbers sorted in descending order:");
        PrintNumbers(sortedNumbers);

        // Using a lambda expression to square each number
        var squaredNumbers = numbers.Select(n => n * n);
        Console.WriteLine("Squared numbers:");
        PrintNumbers(squaredNumbers);
    }

    static void PrintNumbers(IEnumerable<int> numbers)
    {
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine();
    }
}
