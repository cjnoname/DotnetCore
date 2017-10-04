using DotnetCore.Data;
using DotnetCore.Interfaces;
using DotnetCore.Model;
using DotnetCore.Model.S3;
using DotnetCore.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Microsoft.Extensions.Options;

namespace DotnetCore.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _context;
        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task FetchDataFromS3(string fileKey)
        {
            var fetchS3Request = new FetchS3Request
            {
                BucketName = "cjcj123",
                FileKey = fileKey
            };
            var fileContent = await S3Helper.FetchData(fetchS3Request);
            var students = JsonConvert.DeserializeObject<List<Student>>(fileContent);
            students.ForEach(x =>
            {
                x.Id = 0;
            });
            await _context.AddRangeAsync(students);
            await _context.SaveChangesAsync();
        }

    }
}
