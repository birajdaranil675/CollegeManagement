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
        private readonly ILogger _logger;

        public StudentController(IStudentApplication studentApplication, ILogger<StudentController> logger)
        {
            _studentApplication = studentApplication;
            _logger = logger;
        }


        [HttpGet]
        [Route("GetStudents")]
        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            _logger.LogInformation("Loading student list");
            var students = await _studentApplication.GetStudentsAsync();
            _logger.LogInformation("Successfully loaded student list");
            return students;
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IEnumerable<StudentDto>> AddStudent([Required] StudentInputDto student)
        {
            _logger.LogInformation("Adding student in list");
            var newStudentList = await _studentApplication.AddStudentAsync(student);
            _logger.LogInformation("Successfully added student in list list");
            return newStudentList;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<IEnumerable<StudentDto>> UpdateStudent([FromRoute]int id,[Required] StudentUpdateInputDto student)
        {
            _logger.LogInformation($"Updating student with id {id} in list");
            var newStudentList = await _studentApplication.UpdateStudentAsync(student, id);
            _logger.LogInformation($"Successfully updated student {id} in list list");
            return newStudentList;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<IEnumerable<StudentDto>> DeleteStudent([FromRoute] int id)
        {
            _logger.LogInformation($"Deleting student with id {id} from list");
            var newStudentList = await _studentApplication.DeleteStudentAsync(id);
            _logger.LogInformation($"Successfully deleted student {id} from list list");
            return newStudentList;
        }
    }
}
