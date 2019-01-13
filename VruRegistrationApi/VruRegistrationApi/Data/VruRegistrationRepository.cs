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

        #region Student
        // Add a new student
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        // Retrieve a student
        public async Task<Student> GetStudent(int studentId)
        {
            var result = await _context.Students
                .Where(s => s.Id == studentId)
                .ToListAsync();

            if (result.Count <= 0)
            {
                return null;
            }
            return result.First();
        }

        // Retrieve All students
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var result = await _context.Students.ToListAsync();
            if (result.Count <= 0)
            {
                return null;
            }
            return result.OrderBy(x => x.Id);
        }

        // Update an existing student
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

        // Delete an existing student
        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }
        #endregion

        #region Enrollment
        // Add/assign a course to student
        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
        }

        // Retrieve a specific enrollment
        public async Task<Enrollment> GetCourseEnrollmentForStudent(int studentId, int courseId)
        {
            var courseEnrollments = await (from e in _context.Enrollments
                                     join c in _context.Courses on e.Course.Id equals c.Id
                                     where e.Student.Id == studentId && e.Course.Id == courseId
                                     select e)
                                     .Include(e => e.Course)
                                     .Include(e => e.Student)
                               .ToListAsync();

            if (courseEnrollments.Count <= 0)
            {
                return null;
            }
            return courseEnrollments.First();
        }

        // Retrieve all enrollments for a specific student
        public async Task<IEnumerable<Enrollment>> GetAllCourseEnrollmentsForStudent(int studentId)
        {
            var courseEnrollments = await (from e in _context.Enrollments
                                     join c in _context.Courses on e.Course.Id equals c.Id
                                     where e.Student.Id == studentId
                                     select e)
                                     .Include(e => e.Course)
                                     .Include(e => e.Student)
                               .ToListAsync();
            if (courseEnrollments.Count <= 0)
            {
                return null;
            }
            return courseEnrollments;
        }

        // Update an enrollment
        public bool UpdateEnrollment(Enrollment enrollment)
        {
            try
            {
                _context.Enrollments.Update(enrollment);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        // Delete an enrollment
        public void DeleteEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
        }
        #endregion

        #region Course
        // Get a course
        public async Task<Course> GetCourse(int courseId)
        {
            var result = await _context.Courses
                 .Where(c => c.Id == courseId)
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
        #endregion

        // Save all pending changes
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
