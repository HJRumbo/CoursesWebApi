using Business.Common;
using Business.Dtos;
using Business.Exceptions;
using Business.Interfaces;
using DataAccess.Interfaces;
using Entity;

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

        public async Task<List<StudentDto>> GetAllStudents()
        {
            var students = await _strudentRepository.GetAll();

            return students.Select(s => new StudentDto()
            {
                Id = s.Id,
                Name = s.Name,
                LastName = s.LastName,
                Email = s.Email,
                Identification = s.Identification
            }).ToList();
        }

        public async Task<StudentDto?> GetStudentById(int studentId)
        {
            var student = await _strudentRepository.GetById(studentId)!;

            return student != null ? new StudentDto()
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                Identification = student.Identification
            } : new StudentDto();

        }

        public async Task<Response<bool>> RegisterCourse(StudentCourseDto registrationCourseDto)
        {
            var (student, course) = await ValidateData(registrationCourseDto);

            if (IsRegistredCourse(student, course))
            {
                throw new BadRequestException($"El estudiante {student.Name} {student.LastName} ya se encuentra registrado en el curso {course.Name}. ");
            }

            student.Courses.Add(course);

            return new Response<bool>()
            {
                Data = await _strudentRepository.Update(student) != null,
                Message = "Se registró correctamente al estudiante en el curso. ",
                Successed = true
            };
        }

        public async Task<Response<bool>> RemoveCourse(StudentCourseDto registrationCourseDto)
        {
            var (student, course) = await ValidateData(registrationCourseDto);

            var registredCourse = IsRegistredCourse(student, course);

            if (!registredCourse)
            {
                throw new BadRequestException($"El estudiante {student.Name} {student.LastName} no se encuentra registrado en el curso {course.Name}. ");
            }

            student.Courses.Remove(course);

            return new Response<bool>()
            {
                Data = await _strudentRepository.Update(student) != null,
                Message = "Se removió correctamente al estudiante del curso. ",
                Successed = true
            };
        }

        private async Task<(Student, Course)> ValidateData(StudentCourseDto registrationCourseDto)
        {
            var student = await _strudentRepository.GetById(registrationCourseDto.StudentId)
                ?? throw new BadRequestException($"No se encontró el estudiante con el código {registrationCourseDto.StudentId}. ");

            var course = await _courseRepository.GetById(registrationCourseDto.CourseId)
                ?? throw new BadRequestException($"No se encontró el curso con el código {registrationCourseDto.CourseId}. ");


            return (student, course);
        }

        private static bool IsRegistredCourse(Student student, Course course)
        {

            return student.Courses.Exists(c => c.Id == course.Id);
        }
    }
}
