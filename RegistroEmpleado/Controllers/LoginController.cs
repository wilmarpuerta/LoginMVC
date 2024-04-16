
using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Data;

namespace RegistroEmpleado.Controllers;

public class LoginController : Controller
{
    private readonly BaseContext _context;
    
    public LoginController(BaseContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Acceder(string username, string password)
    {
        var user = _context.Admins.AsQueryable();
        
        if (user.Any(u => u.Names == username && u.Password == password))
        {
            return RedirectToAction("Index", "Home");
        }

        return View("Index", "Login");
    }
}