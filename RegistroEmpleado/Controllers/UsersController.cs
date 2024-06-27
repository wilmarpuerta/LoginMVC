using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Data;
using RegistroEmpleado.Helpers;
using RegistroEmpleado.Providers;
using RegistroEmpleado.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroEmpleado.Controllers;

[Authorize(Roles = "Employee")]
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
            var idUserLog = int.Parse(HttpContext.Session.GetString("UserLog"));
            var user = _context.Users.First(u => u.Id == idUserLog);
            var idRecord = _context.TimeRegisters.Where(t => t.IdUser == idUserLog).OrderByDescending(m => m.Id ).First().Id;
            HttpContext.Session.SetString("RecordUser", idRecord.ToString());
        
        return View(user);
    }

  

        [HttpPost]
public async Task<IActionResult> Insert(IFormFile archivo)
{
    if (archivo == null || archivo.Length == 0)
    {
        return RedirectToAction("Profile");
    }

    string nombreArchivo = archivo.FileName;
    string path = await _helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo);

    var idUserLog = int.Parse(HttpContext.Session.GetString("UserLog"));
    var user = _context.Users.First(u => u.Id == idUserLog);
    user.PhotoProfile = nombreArchivo;
    await _context.SaveChangesAsync();

    return RedirectToAction("Profile");
}


        public async Task<IActionResult> Record(int id)
        {
            var timeRegisters = await _context.TimeRegisters.Where(m => m.IdUser == id).ToListAsync();
            return View(timeRegisters);
        }

        public async Task<IActionResult> Profile(int id)
        {
            return View(await _context.Users.FirstOrDefaultAsync(m => m.Id == id)); 
        }
        
}