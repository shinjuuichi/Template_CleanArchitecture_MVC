using System.IO;
using BusinessLogicLayer.Commons;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Utils
{
    public static class ImageUtil
    {
        public static async Task<string?> SaveImageAsync(AppConfiguration configuration, Type entityType, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            using var dropbox = new DropboxClient(configuration.DropboxConfig.AccessToken,
                new DropboxClientConfig(configuration.DropboxConfig.AppName));

            var fileName = $"{Guid.NewGuid().ToString().Substring(0, 8)}_{file.FileName}";
            var pathToSave = $"/{entityType.Name}/{fileName}";

            using var stream = file.OpenReadStream();
            try
            {
                await dropbox.Files.UploadAsync(
                   pathToSave,
                   WriteMode.Overwrite.Instance,
                   body: stream);

                return fileName;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task<byte[]?> GetImageAsync(AppConfiguration configuration, Type entityType, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            using var dropbox = new DropboxClient(configuration.DropboxConfig.AccessToken,
                new DropboxClientConfig(configuration.DropboxConfig.AppName));

            var pathToRead = $"/{entityType.Name}/{fileName}";
            try
            {
                var response = await dropbox.Files.DownloadAsync(pathToRead);
                var bytes = response?.GetContentAsByteArrayAsync();
                return bytes?.Result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task<bool> DeleteImageAsync(AppConfiguration configuration, Type entityType, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            using var dropbox = new DropboxClient(configuration.DropboxConfig.AccessToken,
                new DropboxClientConfig(configuration.DropboxConfig.AppName));

            var pathToDelete = $"/{entityType.Name}/{fileName}";
            try
            {
                await dropbox.Files.DeleteV2Async(pathToDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
