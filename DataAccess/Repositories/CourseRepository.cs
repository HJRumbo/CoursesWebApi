using DataAccess.Data;
using DataAccess.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        protected readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course?> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<List<Course>> GetAvailableCourses(Student student)
        {
            return await _context.Courses.Include("Students").Where(c => !c.Students.Contains(student)).ToListAsync();
        }


        public async Task<List<Course>> GetCoursesByStudentId(Student student)
        {
            return await _context.Courses.Include("Students").Where(c => c.Students.Contains(student)).ToListAsync();
        }
    }
}
