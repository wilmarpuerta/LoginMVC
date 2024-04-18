using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Data;
using RegistroEmpleado.Models;
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

    public IActionResult Acceder(string username, string password, TimeRegister time)
    {
        /* var user = _context.Users.AsQueryable(); */

        var userfind = _context.Users.FirstOrDefault(u => u.Names == username && u.Password == password);


        if (userfind != null)
        {
            HttpContext.Session.SetString("userLog", userfind.Id.ToString());
            time.IdUser = userfind.Id;
            time.LoginAt = DateTime.Now;
            _context.TimeRegisters.Add(time);
            _context.SaveChanges();

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