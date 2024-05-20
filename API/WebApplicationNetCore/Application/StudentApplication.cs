using MyCollege.Api.DTOs;
using MyCollege.Api.Infrastructure;
using MyCollege.Api.Model;
using MyCollege.Api.Services;

namespace MyCollege.Api.Application
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IStudentService _studentService;
        private readonly ICOMapper _coMapper;

        public StudentApplication(IStudentService studentService, ICOMapper mapper)
        {
            _studentService= studentService;
            _coMapper = mapper;
        }
        public async Task<IEnumerable<StudentDto>> AddStudentAsync(StudentInputDto student)
        {
            if (student == null)
                throw new Exception("Input information cannot be null");

            var newStudent = _coMapper.Map<Student>(student);
            await _studentService.AddStudentAsync(newStudent);

            var res = await _studentService.GetStudentsAsync();

            return _coMapper.Map<IEnumerable<StudentDto>>(res);
        }

        public async Task<IEnumerable<StudentDto>> DeleteStudentAsync(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            var res = await _studentService.GetStudentsAsync();

            return _coMapper.Map<IEnumerable<StudentDto>>(res);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = await _studentService.GetStudentsAsync();

            return _coMapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<IEnumerable<StudentDto>> UpdateStudentAsync(StudentUpdateInputDto student, int id)
        {
            await _studentService.UpdateStudentAsync(_coMapper.Map<Student>(student), id);

            var res = await _studentService.GetStudentsAsync();

            return _coMapper.Map<IEnumerable<StudentDto>>(res);
        }
    }
}
