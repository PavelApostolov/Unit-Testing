using System;

namespace Task1_StudentsAndCourses
{
    public class Student 
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;  
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be empty!");
                }

                this.name = value;
            }
        }
        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            private set
            {
                if (value > 99999 || value < 10000)
                {
                    throw new ArgumentException("Unique number is between 10000 and 99999!");
                }
                else
                {
                    this.uniqueNumber = value;
                }
            }
        }
    }
}
