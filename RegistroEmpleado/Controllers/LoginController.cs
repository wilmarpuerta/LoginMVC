
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
        var user = _context.Users.AsQueryable();

        if (user.Any(u => u.Names == username && u.Password == password))
        {
            var userLog = _context.Users.Where(u => u.Names == username && u.Password == password).First();
            HttpContext.Session.SetString("UserName", userLog.Names);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Danger = "Credenciales Incorrectas!";
            ViewBag.ClaseElemento = "is-invalid";
        }

        return View("Index", "Login");
    }
}