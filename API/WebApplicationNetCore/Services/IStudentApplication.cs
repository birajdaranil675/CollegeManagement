using MyCollege.Api.DTOs;

namespace MyCollege.Api.Services
{
    public interface IStudentApplication
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<IEnumerable<StudentDto>> AddStudentAsync(StudentInputDto student);
        Task<IEnumerable<StudentDto>> UpdateStudentAsync(StudentUpdateInputDto student, int id);
        Task<IEnumerable<StudentDto>> DeleteStudentAsync(int id);
    }
}
