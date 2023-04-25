using System;
//using publicaccessmodifier.newnamespace; explicit import

namespace MyApplication
{

    class Student
    {
        public string name = "Sheeran";

        public void print()
        {
            Console.WriteLine("Hello from Student class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // creating object of Student class
            Student student1 = new Student();

            // accessing name field and printing it
            Console.WriteLine("Name: " + student1.name);

            // accessing print method from Student
            student1.print();
            Console.ReadLine();

            publicaccessmodifier.newnamespace.College college = new publicaccessmodifier.newnamespace.College();

            Console.WriteLine(college.name);
        }
    }
}