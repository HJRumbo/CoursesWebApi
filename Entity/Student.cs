using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Student
    {
        [Key] 
        public int Id { get; set; }
        public string Identification { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new();
    }
}
