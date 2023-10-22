using System.ComponentModel.DataAnnotations;

namespace Business.Dtos
{
    public class RegistrationCourseDto
    {
        [Required(ErrorMessage = "El código del estudiante es requerido")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "El código del curso es requerido")]
        public int CourseId { get; set; }
    }
}
