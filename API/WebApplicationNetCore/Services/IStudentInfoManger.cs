using MyCollege.Api.Model;

namespace MyCollege.Api.Services
{
    public interface IStudentInfoManger
    {
        Task<IEnumerable<Student>> LoadStudents();
        Task AddStudentInformation(IEnumerable<Student> newStudentList);
    }
}
