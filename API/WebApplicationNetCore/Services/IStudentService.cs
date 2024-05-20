using MyCollege.Api.Model;

namespace MyCollege.Api.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task AddStudentAsync(Student newStudent);
        Task UpdateStudentAsync(Student student, int id);
        Task DeleteStudentAsync(int id);
    }
}
