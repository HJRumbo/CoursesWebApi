namespace Business.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Identification { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
