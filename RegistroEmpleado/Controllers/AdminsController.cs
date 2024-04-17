using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Models;
using RegistroEmpleado.Data;

namespace RegistroEmpleado.Controllers
{
    public class  AdminsController : Controller
    {
        private readonly BaseContext _context;

        public AdminsController(BaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
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
        public async Task<IActionResult> Register(User Use)
        {
            Use.PhotoProfile = "User.svg";
            _context.Users.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
     var user = await _context.TimeRegisters.FirstOrDefaultAsync(m => m.id_User == id);
}

  [HttpPost]
        public async Task<IActionResult> (User Use)
        {
            Use.LoginAt=System.DataTime;
            Use.LogOffAt=System.DataTime;
            _context.TimeRegisters.Add(emp);
            _context.SaveChanges();
        }


    }
}