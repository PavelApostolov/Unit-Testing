namespace School.Tests
{
    using System;
    using Task1_StudentsAndCourses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_NameInitialize_ShouldBeProporly()
        {
            var school = new School();
            string name = "Pesho";
            var pesho = school.RegistrationSudent(name);

            Assert.AreEqual(name, pesho.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_NameInitializeIsNull_ShouldBeThrowArgumentException()
        {
            var school = new School();
            string name = null;
            school.RegistrationSudent(name);
        }

        [TestMethod]
        public void Students_ShouldhaveUniqueNumberes()
        {
            var school = new School();
            Student[] students = new Student[3]
            {
                school.RegistrationSudent("Pesho"),
                school.RegistrationSudent("Gosho"),
                school.RegistrationSudent("Ivan"),
            };

            for (int current = 0; current < students.Length; current++)
            {
                for (int compareToIndex = current + 1; compareToIndex < students.Length; compareToIndex++)
                {
                    Assert.AreNotEqual(students[current].UniqueNumber, students[compareToIndex].UniqueNumber);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_NumberIsInvalid_ShouldThrolArgumentExeption()
        {
            const int InvalidNumber = 100000;
            var school = new School();

            for (int i = 0; i <= InvalidNumber; i++)
            {
                school.RegistrationSudent("Pesho");
            }
        }

    }
}
