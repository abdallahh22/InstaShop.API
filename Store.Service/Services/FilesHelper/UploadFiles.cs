using Microsoft.AspNetCore.Http;

namespace Store.API.Helpers
{
    public class UploadFiles
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(folderpath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;

        }

    }
}
