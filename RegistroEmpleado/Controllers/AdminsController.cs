using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RegistroEmpleado.Models;
using RegistroEmpleado.Data;

namespace RegistroEmpleado.Controllers
{
    public class  AdminsController : Controller
    {
        public readonly BaseContext _context;

        public AdminsController(BaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admins.ToListAsync());
        }
    }
}