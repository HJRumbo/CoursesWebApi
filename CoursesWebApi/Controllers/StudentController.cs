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

        [HttpPut("RegisterCourse")]
        public async Task<IActionResult> RegisterCourse(StudentCourseDto studentCourseDto)
        {
            var response = await _studentService.RegisterCourse(studentCourseDto);

            return Ok(response);
        }

        [HttpPut("RemoveCourse")]
        public async Task<IActionResult> RemoveCourse(StudentCourseDto studentCourseDto)
        {
            var response = await _studentService.RemoveCourse(studentCourseDto);

            return Ok(response);
        }
    }
}
