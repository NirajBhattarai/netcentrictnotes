using System;
using namespaceexample.model;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            st.firstname = "sagara";
            st.lastname = "xyz";
            st.rollno = 10;
            st.address = "manigram";
            Console.WriteLine(st.firstname);
            Console.WriteLine(st.lastname);
            Console.Write(st.rollno);
        }
    }
}