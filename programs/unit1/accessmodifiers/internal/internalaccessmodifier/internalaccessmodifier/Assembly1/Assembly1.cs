// Code on Assembly1
using System;
using Assembly;

namespace Assembly1
{

     class StudentName
    {
        internal string name = "different assembly";
    }

    class Teacher : Person
    {

        public string getName()
        {
            return this.name;
        }
    }
}