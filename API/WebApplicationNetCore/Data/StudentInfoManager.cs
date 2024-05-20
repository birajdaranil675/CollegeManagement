using System.Text.Json.Serialization;
using System.Text.Json;
using MyCollege.Api.Model;
using MyCollege.Api.Services;
using MyCollege.Api.DTOs;

namespace MyCollege.Api.Data
{
    public class StudentInfoManager : IStudentInfoManger
    {
       

        //private readonly 

        public async Task<IEnumerable<Student>> LoadStudents()
        {
            string filePath = "C:\\MyProjects\\CollegeManagement\\API\\StudentData\\StudentInfo.json";
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

            return studentInfo;
        }

        public async Task AddStudentInformation(IEnumerable<Student> newStudentList)
        {
            string filePath = "C:\\MyProjects\\CollegeManagement\\API\\StudentData\\StudentInfo.json";
            var serializeOption = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
                Converters = { new JsonStringEnumConverter() }

            };
            var jsonText = JsonSerializer.Serialize(newStudentList, serializeOption);
            await File.WriteAllTextAsync(filePath, jsonText);
        }
    }
}
