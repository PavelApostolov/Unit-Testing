namespace Task1_StudentsAndCourses
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsInCourse = 30;

        public Course()
        {
            this.StudentsInCourse = new List<Student>();
        }

        public IList<Student> StudentsInCourse { get; private set; }

        public void AddStudent(Student stud)
        {
            // Students in a course should be less than 30
            if (this.StudentsInCourse.Count >= MaxStudentsInCourse)
            {
                throw new ArgumentException("Students in a course should be less than 30!");
            }
            else if(this.StudentsInCourse.Contains(stud))
            {
                throw new ArgumentException($"{stud.Name} is already added!");
            }
            else
            {
                this.StudentsInCourse.Add(stud);
            }
        }

        public void RemoveStudent(Student stud)
        {
            if (this.StudentsInCourse.Contains(stud))
            {
                this.StudentsInCourse.Remove(stud);
            }
            else
            {
                throw new ArgumentException($"{ stud.Name } is not enrolled for the this course!");
            }
        }
    }
}
