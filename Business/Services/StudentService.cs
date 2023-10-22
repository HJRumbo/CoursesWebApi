using Business.Dtos;
using Business.Interfaces;
using DataAccess.Interfaces;
using Entity;
using System.Linq;

namespace Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _strudentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _strudentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _strudentRepository.GetAll();
        }

        public async Task<Student?> GetStudentById(int studentId)
        {
            return await _strudentRepository.GetById(studentId)!;

        }

        public async Task<bool> RegisterCourse(RegistrationCourseDto registrationCourseDto)
        {
            var student = await _strudentRepository.GetById(registrationCourseDto.StudentId);

            var course = await _courseRepository.GetById(registrationCourseDto.CourseId);

            var registredCourse = student.Courses.Where(c => c.Id == registrationCourseDto.CourseId).Count() > 0;

            if (registredCourse)
            {
                throw new Exception("Ya está registrado. ");
            }

            student.Courses.Add(course);

            return await _strudentRepository.Update(student) != null;
        }
    }
}
