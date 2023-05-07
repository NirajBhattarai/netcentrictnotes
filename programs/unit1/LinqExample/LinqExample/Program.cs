

using System;
using System.Collections.Generic;
using System.Linq;

class LINQExamples
{
    static void Main()
    {
        // Data Source
        List<Student> students = new List<Student>
        {
            new Student {Id = 1, Name = "Alice", Age = 20, GPA = 3.5},
            new Student {Id = 2, Name = "Bob", Age = 22, GPA = 3.0},
            new Student {Id = 3, Name = "Charlie", Age = 24, GPA = 3.2},
            new Student {Id = 4, Name = "David", Age = 21, GPA = 3.8},
            new Student {Id = 5, Name = "Eve", Age = 19, GPA = 3.9}
        };

        // 1. Filtering Data
        var topStudents = students.Where(s => s.GPA >= 3.5);
        PrintResults("Filtering Data", topStudents);

        // 2. Sorting Data
        var sortedStudents = students.OrderBy(s => s.Age);
        PrintResults("Sorting Data", sortedStudents);

        // 3. Selecting Specific Properties
        var studentNames = students.Select(s => s.Name);
        PrintResults("Selecting Specific Properties", studentNames);

        // 4. Grouping Data
        var ageGroups = students.GroupBy(s => s.Age);
        PrintGroupResults("Grouping Data", ageGroups);

        // 5. Joining Data Collections
        List<Course> courses = new List<Course>
        {
            new Course {Id = 1, Name = "Math", Instructor = "John"},
            new Course {Id = 2, Name = "History", Instructor = "Jane"},
            new Course {Id = 3, Name = "Physics", Instructor = "Tom"}
        };

        var courseStudents = from c in courses
                             join s in students on c.Id equals s.Id
                             select new { CourseName = c.Name, StudentName = s.Name };

        PrintResults("Joining Data Collections", courseStudents);

        // 6. Aggregating Data
        double averageGPA = students.Average(s => s.GPA);
        Console.WriteLine("Aggregating Data: Average GPA: {0}", averageGPA);

        // 7. Conditional Aggregation
        int totalStudentsBelow35GPA = students.Count(s => s.GPA < 3.5);
        Console.WriteLine("Conditional Aggregation: Total Students below 3.5 GPA: {0}", totalStudentsBelow35GPA);

        // 8. Partitioning Data
        var firstThreeStudents = students.Take(3);
        PrintResults("Partitioning Data (Take)", firstThreeStudents);

        var studentsAfterFirstThree = students.Skip(3);
        PrintResults("Partitioning Data (Skip)", studentsAfterFirstThree);

        // 9. Generating Data
        var range = Enumerable.Range(1, 5);
        Console.WriteLine("Generating Data: Range: {0}", string.Join(", ", range));

        // 10. Combining Data Collections
        List<Student> additionalStudents = new List<Student>
    {
        new Student {Id = 6, Name = "Frank", Age = 23, GPA = 3.3},
        new Student {Id = 7, Name = "Grace", Age = 22, GPA = 3.6}
    };

        var allStudents = students.Concat(additionalStudents);
        PrintResults("Combining Data Collections", allStudents);
    }

    static void PrintResults<T>(string header, IEnumerable<T> items)
    {
        Console.WriteLine(header);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void PrintGroupResults<T, TKey>(string header, IEnumerable<IGrouping<TKey, T>> groups)
    {
        Console.WriteLine(header);
        foreach (var group in groups)
        {
            Console.WriteLine("Key: {0}", group.Key);
            foreach (var item in group)
            {
                Console.WriteLine(item);
            }
        }
        Console.WriteLine();
    }
}

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }

    
public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, GPA: {GPA}";
    }
}

class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Instructor { get; set; }


public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Instructor: {Instructor}";
    }
}
