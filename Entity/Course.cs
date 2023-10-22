using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Course
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Student> Students { get; } = new();
    }
}
