using System;
using VruRegistrationApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using VruRegistrationApi.Models;
using Xunit;
using VruRegistrationApi.Data;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace VruRegistrationApi.Tests
{
    public class StudentControllerTests
    {

        [Fact]
        public void CreateNewStudent()
        {
            // arrange
            var mockRepository = new Mock<IVruRegistrationRepository>();
            StudentController studentController = new StudentController(mockRepository.Object);
            Student student = MockData.GetTestStudents(1).First();

            // act
            var postStudent = studentController.PostStudent(student);

            // assert
            var result = Assert.IsType<CreatedAtActionResult>(postStudent.Result);
            var value = Assert.IsType<Student>(result.Value);
        }

        [Fact]
        public void CreateNewEnrollment()
        {
            // arrange
            var mockRepository = new Mock<IVruRegistrationRepository>();
            mockRepository.Setup(r => r.GetCourse(1))
                          .ReturnsAsync(MockData.GetTestCourses(1).First());
            mockRepository.Setup(r => r.GetStudent(1))
                          .ReturnsAsync(MockData.GetTestStudents(1).First());
            StudentController studentController = new StudentController(mockRepository.Object);
            Enrollment enrollment = MockData.GetTestEnrollments(1).First();

            // act
            var postEnrollment = studentController.PostEnrollment(enrollment.Student.Id, enrollment.Course.Id);

            // assert
            var result = Assert.IsType<CreatedAtActionResult>(postEnrollment.Result);
            var value = Assert.IsType<Enrollment>(result.Value);
        }

        [Fact]
        public void GetStudent()
        {
            // arrange
            var mockRepository = new Mock<IVruRegistrationRepository>();
            mockRepository.Setup(r => r.GetStudent(1))
                          .ReturnsAsync(MockData.GetTestStudents(1).First());
            StudentController studentController = new StudentController(mockRepository.Object);

            // act
            var getStudent = studentController.GetStudent(1);

            // assert
            var result = Assert.IsType<OkObjectResult>(getStudent.Result);
            var value = Assert.IsType<Student>(result.Value);
        }

        [Fact]
        public void GetAllStudents()
        {
            // arrange
            var mockRepository = new Mock<IVruRegistrationRepository>();
            mockRepository.Setup(r => r.GetAllStudents())
                          .ReturnsAsync(MockData.GetTestStudents(5));
            StudentController studentController = new StudentController(mockRepository.Object);

            // act
            var getStudents = studentController.GetStudents();

            // assert
            var result = Assert.IsType<OkObjectResult>(getStudents.Result);
            var value = Assert.IsType<List<Student>>(result.Value);
            Assert.True(value.Count == 5);
        }

        [Fact]
        public void GetStudentEnrollment()
        {
            // arrange
            var mockRepository = new Mock<IVruRegistrationRepository>();
            mockRepository.Setup(r => r.GetCourseEnrollmentForStudent(1,1))
                          .ReturnsAsync(MockData.GetTestEnrollments(1).First());
            StudentController studentController = new StudentController(mockRepository.Object);

            Student student = MockData.GetTestStudents(1).First();
            Course course = MockData.GetTestCourses(1).First();

            // act
            var getEnrollments = studentController.GetEnrollment(student.Id, course.Id);

            // assert
            var result = Assert.IsType<OkObjectResult>(getEnrollments.Result);
            var value = Assert.IsType<Enrollment>(result.Value);
        }

        [Fact]
        public void GetAllStudentEnrollment()
        {
            // arrange
            var mockRepository = new Mock<IVruRegistrationRepository>();
            mockRepository.Setup(r => r.GetAllCourseEnrollmentsForStudent(1))
                          .ReturnsAsync(MockData.GetTestEnrollments(7));
            StudentController studentController = new StudentController(mockRepository.Object);

            Student student = MockData.GetTestStudents(1).First();

            // act
            var getEnrollments = studentController.GetEnrollments(student.Id);

            // assert
            var result = Assert.IsType<OkObjectResult>(getEnrollments.Result);
            var value = Assert.IsType<List<Enrollment>>(result.Value);
            Assert.True(value.Count == 7);
        }

        [Fact]
        public void UpdateStudent()
        {
            // arrange
            Student student = MockData.GetTestStudents(1).First();
            Student updatedStudent = new Student
            {
                Id = student.Id,
                FirstName = "UpdatedFirst",
                MiddleName = "UpdatedMiddle",
                LastName = "UpdatedLast",
                BirthDate = new DateTime(2019, 1, 1)
            };
            var mockRepository = new Mock<IVruRegistrationRepository>();
            mockRepository.Setup(r => r.UpdateStudent(updatedStudent))
                          .Returns(true);
            StudentController studentController = new StudentController(mockRepository.Object);

            // act
            var putStudent = studentController.PutStudent(student.Id, updatedStudent);

            // assert
            var result = Assert.IsType<NoContentResult>(putStudent.Result);
        }

        [Fact]
        public void DeleteStudent()
        {
            // arrange
            Student student = MockData.GetTestStudents(1).First();
            var mockRepository = new Mock<IVruRegistrationRepository>();
            mockRepository.Setup(r => r.GetStudent(student.Id))
                          .ReturnsAsync(student);
            StudentController studentController = new StudentController(mockRepository.Object);

            // act
            var deleteStudent = studentController.DeleteStudent(student.Id);

            // assert
            var result = Assert.IsType<OkObjectResult>(deleteStudent.Result);
            var value = Assert.IsType<Student>(result.Value);
        }
    }
}
