using Microsoft.AspNetCore.Mvc;

namespace RegistroEmpleado.Controllers;

public class HomeController : Controller
{
   
    public IActionResult Index()
    {
        return View();
    }
}
