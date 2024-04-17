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
            return View(await _context.Employees.ToListAsync());
        }
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(Employee emp)
        {
            emp.PhotoProfile = "User.svg";
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

          //Eliminar
          
     public async Task<IActionResult> Delete(int id)
{
    var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
    return View(employee);
}

public async Task<IActionResult> DeleteUser(int id)
{
    var employee = await _context.Employees.FindAsync(id);
    _context.Employees.Remove(employee);
    await _context.SaveChangesAsync();
    return RedirectToAction("Manage");
}
public async Task<IActionResult> Record(int id)
{
     var employee = await _context.TimeRegisters.FirstOrDefaultAsync(m => m.id_employee == id);
}
    }
}