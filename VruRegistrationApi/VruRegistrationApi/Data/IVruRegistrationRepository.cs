using VruRegistrationApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VruRegistrationApi.Data
{
    public interface IVruRegistrationRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<IEnumerable<Enrollment>> GetAllCoursesForStudent(Student student);
        void AddStudent(Student student);
        Task<Student> GetStudent(int studentId);
        bool UpdateStudent(Student student);
        void DeleteStudent(Student student);
        void AddCourse(Course course);
        Task<Course> GetCourse(int courseId);
        bool UpdateCourse(Course course);
        void DeleteCourse(Course course);
        Task<bool> SaveAll();
    }
}