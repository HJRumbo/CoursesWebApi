using DataAccess.Data;
using DataAccess.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Student data)
        {
            _context.Students.Remove(data);
            _context.SaveChanges();
        }

        public async Task<List<Student>> GetAll() => await _context.Students.ToListAsync();

        public async Task<Student?> GetById(int id) => await _context.Students.Include("Courses").FirstOrDefaultAsync(s => s.Id == id)!;

        public async Task<Student> Saved(Student data)
        {
            var entity = await _context.Students.AddAsync(data);
            await _context.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<Student> Update(Student data)
        {
            var entity = _context.Students.Update(data);
            await _context.SaveChangesAsync();

            return entity.Entity;
        }
    }
}
