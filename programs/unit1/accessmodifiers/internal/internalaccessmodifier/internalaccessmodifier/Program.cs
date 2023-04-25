using System;
using Assembly1;
using InternalDemo;

namespace Assembly
{

     class Person
    {
        internal string name = "Sheeran";
    }

    class Student:Person
    {
        public string getName()
        {
            return this.name;
                }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person();

            person.name = "xyz";

            

            // creating object of Student class
            StudentName theStudent = new StudentName();

            // accessing name field and printing it
            Console.WriteLine("Name: " + theStudent.name);
            Console.ReadLine();

            Teacher teacher = new Teacher();

            Class1 class1 = new Class1();
            class1.rollno = 1;
            class1.name = 

            
        }
    }
}