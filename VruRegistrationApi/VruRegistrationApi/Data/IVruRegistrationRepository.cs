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

        void AddEnrollment(Enrollment enrollment);
        Task<Enrollment> GetCourseEnrollmentForStudent(int studentId, int courseId);
        Task<IEnumerable<Enrollment>> GetAllCourseEnrollmentsForStudent(int studentId);
        bool UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(Enrollment enrollment);

        Task<Course> GetCourse(int courseId);

        Task<bool> SaveAll();
    }
}