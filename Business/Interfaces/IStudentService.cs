using Business.Dtos;
using Entity;

namespace Business.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int studentId);
        Task<bool> RegisterCourse(RegistrationCourseDto registrationCourseDto);
    }
}
