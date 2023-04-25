using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class TestArraysClass
{
    static void Main()
    {
        // Declare a single-dimensional array of 5 integers.
        int[] array1 = new int[5];

        // Declare and set array element values.
        int[] array2 = new int[] { 1, 3, 5, 7, 9 };

        // Alternative syntax.
        int[] array3 = { 1, 2, 3, 4, 5, 6 };

        // Declare a two dimensional array.
        int[,] multiDimensionalArray1 = new int[2, 3];

        // Declare and set array element values.
        int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        // Declare a jagged array.
        int[][] jaggedArray = new int[6][];

        // Set the values of the first array in the jagged array structure.
        jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

        // Declare an array of custom objects.
        Person[] peoples = new Person[]
        {
            new Person("Alice", 25),
            new Person("Bob", 30),
            new Person("Charlie", 35)
        };

        // Print out the arrays.
        Console.WriteLine("Array1:");
        foreach (int i in array1) Console.Write(i + " ");

        Console.WriteLine("\nArray2:");
        foreach (int i in array2) Console.Write(i + " ");

        Console.WriteLine("\nArray3:");
        foreach (int i in array3) Console.Write(i + " ");

        Console.WriteLine("\nMultiDimensionalArray1:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(multiDimensionalArray1[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("MultiDimensionalArray2:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(multiDimensionalArray2[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("JaggedArray:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (jaggedArray[i] != null)
            {
                foreach (int j in jaggedArray[i]) Console.Write(j + " ");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Peoples:");
        foreach (Person person in peoples)
        {
            Console.WriteLine($"{person.Name} is {person.Age} years old");
        }
    }
}
