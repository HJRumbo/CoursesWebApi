using Business.Dtos;
using Entity;

namespace Business.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDto> GetCourseById(int courseId);
        Task<List<CourseDto>> GetCoursesByStudentId(int studentId);
    }
}
