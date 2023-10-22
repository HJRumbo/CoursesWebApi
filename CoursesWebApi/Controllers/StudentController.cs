using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoursesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            return Ok(await _studentService.GetStudentById(studentId));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCourse(RegistrationCourseDto registrationCourseDto)
        {
            var response = await _studentService.RegisterCourse(registrationCourseDto);

            return Ok(response);
        }
    }
}
