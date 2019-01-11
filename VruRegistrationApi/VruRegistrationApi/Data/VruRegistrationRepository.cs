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

        public async Task<IEnumerable<Enrollment>> GetAllCoursesForStudent(Student student)
        {
            var result = await _context.Enrollments
                .Where(enr => enr.Student == student)
                .ToListAsync();
            return result.OrderBy(x => x.Id);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var result = await _context.Students.ToListAsync();
            return result.OrderBy(x => x.Id);
        }

        public async Task<Course> GetCourse(int courseId)
        {
            var result = await _context.Courses
                .Where(c => c.ID == courseId)
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
