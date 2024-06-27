
namespace RegistroEmpleado.Providers
{
    public class PathProvider
    {
        public enum Folders
        {
            Images = 1
        }

        private readonly IWebHostEnvironment _hostEnvironment;

        public PathProvider(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public string MapImagePath(string fileName)
        {
            string imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
            return imagePath;
        }
    }
}
