using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoursesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetStudentCourses/{studentId}")]
        public async Task<IActionResult> GetCoursesByStudentId(int studentId)
        {
            return Ok(await _courseService.GetCoursesByStudentId(studentId));
        }

        [HttpGet("GetAvailableCourses/{studentId}")]
        public async Task<IActionResult> GetAvailableCourses(int studentId)
        {
            return Ok(await _courseService.GetAvailableCourses(studentId));
        }
    }
}
