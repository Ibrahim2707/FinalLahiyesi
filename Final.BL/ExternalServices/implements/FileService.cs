using Final.BL.ExternalServices.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Final.Core.Entities;

namespace Final.BL.ExternalServices.implements
{
    public class FileService : IFileService
    {

        private readonly Cloudinary _cloudinary;
        private const long MaxSize = 2 * 1024 * 1024;

        public FileService(IOptions<CloudinarySettings> settings)
        {
            var s = settings.Value;
            var account = new Account(s.CloudName, s.ApiKey, s.ApiSecret);
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0) throw new Exception("Image is empty!");

            if (file.Length > MaxSize) throw new Exception("File size cannot exceed 2MB.");

            var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                throw new Exception("Invalid file type. Only .jpg, .jpeg, .png, .gif, .webp are allowed.");

            // folderPath-i Cloudinary folder kimi istifadə edirik (məs: "uploads/employees")
            var folder = folderPath.Replace("\\", "/").Trim('/');

            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = folder,
                UseFilename = false,
                UniqueFilename = true,
                Overwrite = false
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            if (result.Error != null)
                throw new Exception($"Cloudinary upload error: {result.Error.Message}");

            // SecureUrl — HTTPS Cloudinary linki qaytarır
            return result.SecureUrl.ToString();
        }

        public async Task DeleteImageAsync(string url)
        {
            if (string.IsNullOrEmpty(url)) return;

            // Cloudinary URL-dən public_id çıxarırıq
            // Məs: https://res.cloudinary.com/ddycglatk/image/upload/v123/uploads/employees/abc123.jpg
            // PublicId: uploads/employees/abc123
            var uri = new Uri(url);
            var segments = uri.AbsolutePath.Split('/');

            // "upload" sözdən sonrakı hissə (version daxil olmadan) public_id-dir
            var uploadIndex = Array.IndexOf(segments, "upload");
            if (uploadIndex < 0 || uploadIndex + 1 >= segments.Length)
                return;

            // Version seqmenti (v123456) atılır
            var afterUpload = segments.Skip(uploadIndex + 1).ToArray();
            if (afterUpload[0].StartsWith("v") && long.TryParse(afterUpload[0][1..], out _))
                afterUpload = afterUpload.Skip(1).ToArray();

            var publicId = string.Join("/", afterUpload);
            // Extensionu sil
            publicId = Path.ChangeExtension(publicId, null).Replace("\\", "/");

            var deleteParams = new DeletionParams(publicId);
            await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}