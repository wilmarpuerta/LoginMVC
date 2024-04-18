using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Data;
namespace RegistroEmpleado.Controllers;

public class UsersController : Controller
{
    private readonly BaseContext _context;
    
    public UsersController(BaseContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var id = HttpContext.Session.GetString("userLog");
        var user = _context.Users.First(u => id != null && u.Id == int.Parse(id));
        return View(user);
    }
}