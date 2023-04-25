using System;
namespace protectedaccessmodifier.model
{
    public class Student:Person
    {
        public Student()
        {
        }


        public void setFirstName(string name)
        {
            this.firstname = name;
        }

        public string getFirstName()
        {
            return this.firstname;
        }

    }
}

