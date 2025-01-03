using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.CoreHeplers
{
    public class CloudinaryHelper
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryHelper(IConfiguration configuration)
        {
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public string NormalizePublicId(string studentId)
        {
            return studentId.Replace(".", "_");
        }

        public async Task<string> UploadImageAsync(byte[] imageBytes, string studentId)
        {

            try
            {
                string publicId = NormalizePublicId(studentId);
                using (var imageStream = new MemoryStream(imageBytes))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription($"student_photos/{studentId}.jpg", imageStream),
                        AssetFolder = "student_photos",
                        PublicId = publicId
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult?.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }

                    return uploadResult?.SecureUrl?.ToString();
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc báo cho người dùng về sự cố
                Console.WriteLine($"Error uploading image: {ex.Message}");
                return null;
            }

        }
        public async Task<bool> DeleteImageAsync(string publicId)
        {
            try
            {
                var deleteParams = new DeletionParams(publicId);

                var deletionResult = await _cloudinary.DestroyAsync(deleteParams);

                return deletionResult.Result == "ok" || deletionResult.Result == "not found";
            }
            catch
            {
                return false; 
            }
        }
    }
}
