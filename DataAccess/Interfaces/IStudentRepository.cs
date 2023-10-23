using Entity;

namespace DataAccess.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetById(int id);
        Task<Student> Save(Student data);
        Task<Student> Update(Student data);
    }
}
