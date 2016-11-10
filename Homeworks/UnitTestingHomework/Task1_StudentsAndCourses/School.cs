namespace Task1_StudentsAndCourses
{
    using System.Collections.Generic;

    public class School
    {
        private int uniqueNumber = 10000;

        public School()
        {
            this.Courses = new List<Course>();
        }
        
        public IEnumerable<Course> Courses{ get; private set; }


        public Student RegistrationSudent(string name)
        {
            var stud = new Student(name, this.uniqueNumber);
            this.uniqueNumber++;

            return stud;
        }
    }
}
