namespace RegistroEmpleado.Providers
{
    

    public class PathProvider
    {
        private IWebHostEnvironment hostEnvironment;

        public PathProvider(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

 public string MapPath(string fileName)
{
    string carpeta = "images";

    string path = Path.Combine(this.hostEnvironment.WebRootPath, carpeta, fileName);
    return path;
}

    }
}