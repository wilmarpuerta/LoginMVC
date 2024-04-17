
using Microsoft.AspNetCore.Mvc;

namespace RegistroEmpleado.Controllers
{
    public class  AdminsController : Controller
    {
        public IActionResult LogUp()
        {
            return View();
        }
    }
}