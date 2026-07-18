using Microsoft.AspNetCore.Http;
namespace Final.BL.ExternalServices.Abstracts
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile file, string folderPath);
        Task DeleteImageAsync(string file);
    }
}
