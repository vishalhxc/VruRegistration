using VruRegistrationApi.Models;
using System.Collections.Generic;

namespace VruRegistrationApi.Data
{
    public interface IVruRegistrationRepository
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Enrollment> GetAllCoursesForStudent(Student student);
        void AddStudent(Student student);
        Student GetStudent(int studentId);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        void AddCourse(Course course);
        Course GetCourse(int courseId);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
        bool SaveAll();
    }
}