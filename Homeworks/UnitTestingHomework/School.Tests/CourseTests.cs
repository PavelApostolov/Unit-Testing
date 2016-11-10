using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task1_StudentsAndCourses;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_HaveInitializeProperly_ShouldBeNotNull()
        {
            var course = new Course();

            Assert.IsNotNull(course.StudentsInCourse);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void Course_AddedStudentOverrloadCapaciti_ShouldThrowArgumentException()
        {
            const int OverrloadCapaciti = 32;

            var math = new Course();
            var school = new School();

            for (int i = 0; i < OverrloadCapaciti; i++)
            {
                var pesho = school.RegistrationSudent("Pesho" + i);
                math.AddStudent(pesho);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_AddedStudentAlreadyAdded__ShouldThrowArgumentException()
        {
            var school = new School();
            var bulgarianLenguage = new Course();
            var pesho = school.RegistrationSudent("Pesho");

            bulgarianLenguage.AddStudent(pesho);
            bulgarianLenguage.AddStudent(pesho);
        }

        [TestMethod]
        public void Course_ShouldAddedStudentSuccessfully()
        {
            var school = new School();
            var englishLenguage = new Course();
            var pesho = school.RegistrationSudent("Pesho");

            englishLenguage.AddStudent(pesho);
            bool isContainPesho = englishLenguage.StudentsInCourse.Contains(pesho);

            Assert.IsTrue(isContainPesho);
        }

        [TestMethod]
        public void Course_ShouldRemoveStudentOfCorseIfIfAlreadyAdded()
        {
            var school = new School();
            var philosophy = new Course();
            var pesho = school.RegistrationSudent("Pesho");

            philosophy.AddStudent(pesho);
            philosophy.RemoveStudent(pesho);

            Assert.AreEqual(0, philosophy.StudentsInCourse.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_ShouldThrowExceptionWhenTheStudentForRemoveDoNotExist()
        {
            var school = new School();
            var philosophy = new Course();
            var pesho = school.RegistrationSudent("Pesho");

            philosophy.RemoveStudent(pesho);

        }
    }
}
