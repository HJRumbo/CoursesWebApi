using Entity;

namespace DataAccess.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course?> GetById(int id);
        Task<List<Course>> GetAvailableCourses(Student student);
        Task<List<Course>> GetCoursesByStudentId(Student student);
    }
}
