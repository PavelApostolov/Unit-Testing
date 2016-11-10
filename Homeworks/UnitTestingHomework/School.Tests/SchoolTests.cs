using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task1_StudentsAndCourses;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_HaveInitializeProperly_ShouldBeNotNull()
        {
            // Arrange
            var school = new School();

            // Act   // Assert
            Assert.IsNotNull(school.Courses);
        }

        [TestMethod]
        public void School_ShouldRegisrationStudentProperly_ShouldReturnInstansOfStudent()
        {
            var school = new School();
            var pesho = school.RegistrationSudent("pesho");

            Assert.IsNotNull(pesho);
        }
    }
}
