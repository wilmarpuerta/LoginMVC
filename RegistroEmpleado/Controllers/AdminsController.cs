using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Models;
using RegistroEmpleado.Data;

namespace RegistroEmpleado.Controllers;

[Authorize(Roles = "Admin")]
public class AdminsController : Controller
{
    private readonly BaseContext _context;

    public AdminsController(BaseContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var idUserLog = int.Parse(HttpContext.Session.GetString("UserLog") ?? string.Empty);
        var idRecord = _context.TimeRegisters.Where(t => t.IdUser == idUserLog).OrderByDescending(m => m.Id ).First().Id;
        HttpContext.Session.SetString("RecordUser", idRecord.ToString());
        return View();
    }

    public async Task<IActionResult> Manage()
    {
        return View(await _context.Users.ToListAsync());
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        user.PhotoProfile = "User.svg";
        user.TipoUser = 2;
        _context.Users.Add(user);
        _context.SaveChanges();
        return RedirectToAction("Manage");
    }

    //Eliminar

    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        return View(user);
    }

    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Manage");
    }


    public async Task<IActionResult> Record(int id)
    {
        var timeRegisters = await _context.TimeRegisters.Where(m => m.IdUser == id).ToListAsync();
        return View(timeRegisters);
    }
}