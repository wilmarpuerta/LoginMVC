using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Data;
using RegistroEmpleado.Models;

namespace RegistroEmpleado.Controllers;

public class HomeController : Controller
{
    private readonly BaseContext _context;

    public HomeController(BaseContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var id = HttpContext.Session.GetString("userLog");
        var user = _context.Users.First(u => u.Id == int.Parse(id));
        return View(user);
    }
}
