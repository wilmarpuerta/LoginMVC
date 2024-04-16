
using Microsoft.AspNetCore.Mvc;

namespace RegistroEmpleado.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}