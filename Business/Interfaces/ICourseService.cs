using Business.Dtos;

namespace Business.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDto> GetCourseById(int courseId);
        Task<List<CourseDto>> GetAvailableCourses(int studentId);
        Task<List<CourseDto>> GetCoursesByStudentId(int studentId);
    }
}
