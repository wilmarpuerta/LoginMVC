
using RegistroEmpleado.Providers;

namespace RegistroEmpleado.Helpers
{
    public class HelperUploadFiles
    {
        private readonly PathProvider _pathProvider;

        public HelperUploadFiles(PathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public async Task<string> UploadFilesAsync(IFormFile formFile, string fileName)
        {
            string path = _pathProvider.MapImagePath(fileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return path;
        }
    }
}
