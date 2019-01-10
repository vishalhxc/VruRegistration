using System;
using System.Collections.Generic;
using System.Linq;
using VruRegistrationApi.Models;

namespace VruRegistrationApi.Data
{
    public class VruRegistrationRepository : IVruRegistrationRepository
    {
        private readonly VruRegistrationDbContext _context;

        public VruRegistrationRepository(VruRegistrationDbContext context)
        {
            _context = context;
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }

        public IEnumerable<Enrollment> GetAllCoursesForStudent(Student student)
        {
            return _context.Enrollments
                .Where(enr => enr.Student == student)
                .ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students;
        }

        public Course GetCourse(int courseId)
        {
            return _context.Courses
                .Where(c => c.ID == courseId)
                .First();
        }

        public Student GetStudent(int studentId)
        {
            return _context.Students
                .Where(s => s.Id == studentId)
                .First();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
