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
        User user = null;
        
        if (HttpContext.Session.GetString("UserLog") != null)
        {
            var idUserLog = int.Parse(HttpContext.Session.GetString("UserLog"));
            user = _context.Users.First(u => u.Id == idUserLog);
            var idRecord = _context.TimeRegisters.Where(t => t.IdUser == idUserLog).OrderByDescending(m => m.Id ).First().Id;
            HttpContext.Session.SetString("RecordUser", idRecord.ToString());
            
        }
        
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