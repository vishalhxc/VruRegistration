using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public void AddEnrollment(Course course)
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

        public IEnumerable<Course> GetCoursesByStudent(int studentId)
        {
            var enrollments = (from e in _context.Enrollments
                                     join c in _context.Courses on e.Id equals c.Id
                                     where e.Student.Id == studentId
                                     select c)
                                     .ToList();
            return enrollments;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var result = await _context.Students.ToListAsync();
            return result.OrderBy(x => x.Id);
        }

        public async Task<Enrollment> GetEnrollment(int courseId, int studentId)
        {
            var result = await _context.Enrollments
                .Where(c => c.Course.Id == courseId && c.Student.Id == studentId)
                .ToListAsync();

            if (result.Count > 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }

        public async Task<Student> GetStudent(int studentId)
        {
            var result = await _context.Students
                .Where(s => s.Id == studentId)
                .ToListAsync();

            if (result.Count > 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool UpdateCourse(Course course)
        {
            try
            {
                _context.Courses.Update(course);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                _context.Students.Update(student);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
