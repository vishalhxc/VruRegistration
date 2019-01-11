using System.Collections.Generic;
using System.Threading.Tasks;
using VruRegistrationApi.Models;

namespace VruRegistrationApi.Data
{
    public interface IVruRegistrationRepository
    {
        void AddStudent(Student student);
        Task<Student> GetStudent(int studentId);
        Task<IEnumerable<Student>> GetAllStudents();
        bool UpdateStudent(Student student);
        void DeleteStudent(Student student);

        void AddEnrollment(Course course);
        Task<Enrollment> GetEnrollment(int courseId, int studentId);
        IEnumerable<Course> GetCoursesByStudent(int studentId);
        bool UpdateCourse(Course course);
        void DeleteCourse(Course course);

        Task<bool> SaveAll();
    }
}