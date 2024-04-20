using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Data;
using RegistroEmpleado.Helpers;
using RegistroEmpleado.Providers;
using RegistroEmpleado.Models;

namespace RegistroEmpleado.Controllers;

[Authorize]
public class UsersController : Controller
{
    private readonly BaseContext _context;
    private readonly HelperUploadFiles _helperUploadFiles;

    public UsersController(BaseContext context, HelperUploadFiles helperUpload)
    {
        _context = context;
        _helperUploadFiles = helperUpload;
    }

    public IActionResult Index()
    {
        var id = HttpContext.Session.GetInt32("userLog");
        var user = _context.Users.First(u => u.Id == id);
        return View(user);
    }

    public IActionResult Profile()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Insert(User user, IFormFile fotoArchivo)
    {
        var nombreArchivo = fotoArchivo.FileName;
        var pathFoto = await _helperUploadFiles.UploadFilesAsync(fotoArchivo);

        user.PhotoProfile = nombreArchivo;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Profile");
    }
}