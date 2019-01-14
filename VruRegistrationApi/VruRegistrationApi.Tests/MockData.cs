using System;
using System.Collections.Generic;
using System.Linq;
using VruRegistrationApi.Models;

namespace VruRegistrationApi.Tests
{
    public static class MockData
    {
        public static List<Course> GetTestCourses(int number)
        {
            var courses = new List<Course>();
            for (int i = 1; i <= number; i++)
            {
                courses.Add(new Course
                {
                    Id = i,
                    Name = $"CourseName-{i}",
                    Description = $"Description-{i}",
                    InstructorName = $"Instructor-{i}",
                    StartDate = new DateTime(2018, 1, 1),
                    EndDate = new DateTime(2018, 06, 30),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(14, 0, 0),
                    Credit = 4,
                    Schedule = "TR"
                });
            }
            return courses;
        }

        public static List<Student> GetTestStudents(int number)
        {
            var students = new List<Student>();
            for (int i = 1; i <= number; i++)
            {
                students.Add(new Student()
                {
                    Id = i,
                    FirstName = $"First-{i}",
                    MiddleName = $"Middle-{i}",
                    LastName = $"Last-{i}",
                    BirthDate = new DateTime(2000, 6, 1)
                });
            }
            return students;
        }

        public static List<Enrollment> GetTestEnrollments(int number)
        {
            var enrollments = new List<Enrollment>();
            Student student = GetTestStudents(1).First();
            var courses = GetTestCourses(number);
            foreach (Course c in courses)
            {
                enrollments.Add(new Enrollment
                {
                    Course = c,
                    Student = student
                });
            }
            return enrollments;
        }
    }
}
