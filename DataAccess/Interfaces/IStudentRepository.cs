using Entity;

namespace DataAccess.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetById(int id);
        Task<Student> Saved(Student data);
        Task<Student> Update(Student data);
        void Delete(Student data);
    }
}
