using Business.Common;
using Business.Dtos;

namespace Business.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllStudents();
        Task<StudentDto?> GetStudentById(int studentId);
        Task<Response<bool>> RegisterCourse(StudentCourseDto registrationCourseDto);
        Task<Response<bool>> RemoveCourse(StudentCourseDto registrationCourseDto);
    }
}
