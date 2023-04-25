using System;

class Student
{
    private string _name;
    private int _age;
    private string _major;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public string Major
    {
        get { return _major; }
        set { _major = value; }
    }

    // Default constructor
    public Student()
    {
        Name = "John Doe";
        Age = 18;
        Major = "Undeclared";
    }

    // Parameterized constructor
    public Student(string name, int age, string major)
    {
        Name = name;
        Age = age;
        Major = major;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student();  // Creates a student with default values
        Student student2 = new Student("Alice Smith", 20, "Computer Science");  // Creates a student with specific values

        Console.WriteLine("Student 1:");
        Console.WriteLine("Name: " + student1.Name);
        Console.WriteLine("Age: " + student1.Age);
        Console.WriteLine("Major: " + student1.Major);
        Console.WriteLine();

        Console.WriteLine("Student 2:");
        Console.WriteLine("Name: " + student2.Name);
        Console.WriteLine("Age: " + student2.Age);
        Console.WriteLine("Major: " + student2.Major);
        Console.WriteLine();
    }
}
