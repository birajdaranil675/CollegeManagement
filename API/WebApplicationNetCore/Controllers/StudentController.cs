using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MyCollege.Api.DTOs;
using MyCollege.Api.Services;

namespace MyCollege.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentApplication _studentApplication;

        public StudentController(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }


        [HttpGet]
        [Route("GetStudents")]
        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = await _studentApplication.GetStudentsAsync();
            return students;
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IEnumerable<StudentDto>> AddStudent([Required] StudentInputDto student)
        {
            var newStudentList = await _studentApplication.AddStudentAsync(student);

            return newStudentList;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<IEnumerable<StudentDto>> UpdateStudent([FromRoute]int id,[Required] StudentUpdateInputDto student)
        {
            var newStudentList = await _studentApplication.UpdateStudentAsync(student, id);

            return newStudentList;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<IEnumerable<StudentDto>> DeleteStudent([FromRoute] int id)
        {
            var newStudentList = await _studentApplication.DeleteStudentAsync(id);

            return newStudentList;
        }
    }
}
