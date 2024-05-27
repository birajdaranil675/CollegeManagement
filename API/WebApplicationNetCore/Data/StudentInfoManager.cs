using System.Text.Json.Serialization;
using System.Text.Json;
using MyCollege.Api.Model;
using MyCollege.Api.Services;

namespace MyCollege.Api.Data
{
    public class StudentInfoManager : IStudentInfoManger
    {
        private readonly ILogger _logger;

        public StudentInfoManager(ILogger<StudentInfoManager> logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<Student>> LoadStudents()
        {
            _logger.LogInformation($"Getting student list from file");
            string filePath = "..//StudentData//StudentInfo.json"; 
            JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
                Converters = { new JsonStringEnumConverter() }
            };
            await using var studentInfoStream = File.OpenRead(filePath);

            var studentInfo = await JsonSerializer.DeserializeAsync<List<Student>>(studentInfoStream, _serializerOptions);

            if (studentInfo == null)
                throw new Exception("Information not found..");

            _logger.LogInformation($"Successfully found student list from file");
            return studentInfo;
        }

        public async Task AddStudentInformation(IEnumerable<Student> newStudentList)
        {
            _logger.LogInformation($"Writing new student information to file");
            string filePath = "..//StudentData//StudentInfo.json";
            var serializeOption = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
                Converters = { new JsonStringEnumConverter() }

            };
            var jsonText = JsonSerializer.Serialize(newStudentList, serializeOption);
            await File.WriteAllTextAsync(filePath, jsonText);
            _logger.LogInformation($"Successfully written new student information to file");
        }
    }
}
