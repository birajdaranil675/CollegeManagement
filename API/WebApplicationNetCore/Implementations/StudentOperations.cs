using MyCollege.Api.Model;
using MyCollege.Api.Services;

namespace MyCollege.Api.Implementations
{
    public class StudentOperations : IStudentService
    {
        private readonly IStudentInfoManger _studentInfoManger;

        public StudentOperations(IStudentInfoManger studentInfoManger)
        {
            _studentInfoManger = studentInfoManger;
        }

        public async Task AddStudentAsync(Student newStudent)
        {
            var studentList = await _studentInfoManger.LoadStudents();
            var newStudentsList = studentList.ToList();
            newStudentsList.Add(newStudent);
            await _studentInfoManger.AddStudentInformation(newStudentsList);
        }

        public async Task DeleteStudentAsync(int id)
        {
            var studentList = (await _studentInfoManger.LoadStudents()).ToList();

            var index = studentList.FindIndex(stud=> stud.Id == id);

            if (index == -1)
                throw new Exception($"Student with id {id} does no exits.");

            studentList.RemoveAt(index);

            await _studentInfoManger.AddStudentInformation(studentList);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentInfoManger.LoadStudents();
        }

        public async Task UpdateStudentAsync(Student updatedStudent, int id)
        {
            var studentList = (await _studentInfoManger.LoadStudents()).ToList();

            var oldData = studentList.FirstOrDefault(stud => stud.Id == id);

            if (oldData == null)
                throw new Exception($"Student with name {updatedStudent.FirstName} does no exits.");

            studentList.Remove(oldData);

            oldData.FirstName = updatedStudent.FirstName;
            oldData.MiddleName = updatedStudent.MiddleName;
            oldData.LastName = updatedStudent.LastName;
            oldData.Email = updatedStudent.Email;
            oldData.Phone = updatedStudent.Phone;

            studentList.Add(oldData);

            await _studentInfoManger.AddStudentInformation(studentList);
        }
    }
}
