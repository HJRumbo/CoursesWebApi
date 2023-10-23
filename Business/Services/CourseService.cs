using Business.Dtos;
using Business.Interfaces;
using DataAccess.Interfaces;

namespace Business.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public CourseService(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public async Task<CourseDto> GetCourseById(int courseId)
        {
            var course = await _courseRepository.GetById(courseId);

            return course == null ? new CourseDto() : new CourseDto()
            {
                Id = course.Id,
                Name = course.Name
            };
        }

        public async Task<List<CourseDto>> GetAvailableCourses(int studentId)
        {
            var student = await _studentRepository.GetById(studentId);

            var courses = await _courseRepository.GetAvailableCourses(student);

            return courses.Select(c => new CourseDto()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }


        public async Task<List<CourseDto>> GetCoursesByStudentId(int studentId)
        {
            var student = await _studentRepository.GetById(studentId);

            if (student is null)
            {
                return new List<CourseDto>();
            }

            var courses = await _courseRepository.GetCoursesByStudentId(student);

            return courses.Select(c => new CourseDto()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
