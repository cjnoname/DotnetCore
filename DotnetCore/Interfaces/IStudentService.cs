
using System.Threading.Tasks;

namespace DotnetCore.Interfaces
{
    public interface IStudentService
    {
        Task FetchDataFromS3(string fileKey);
    }
}
