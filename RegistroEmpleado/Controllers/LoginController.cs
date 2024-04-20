using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            HttpContext.Session.SetInt32("userLog", userfind.Id);
            time.IdUser = userfind.Id;
            time.LoginAt = DateTime.Now;
            time.LogoutAt = null;
            _context.TimeRegisters.Add(time);
            _context.SaveChanges();
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Acceder");
 
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            if (userfind.TipoUser == 1)
            {
                // return Redirect(ReturnUrl == null ? "/Home" : ReturnUrl);
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                return RedirectToAction("Index", "Users");
            }

        }
        else
        {
            ViewBag.Danger = "Credenciales Incorrectas!";
            ViewBag.ClaseElemento = "is-invalid";
        }

        return View("Index", "Login");
    }
    
    
    public async Task<IActionResult> Logout()
    {
        var idUserLog = HttpContext.Session.GetInt32("userLog");
        var idRecords = _context.TimeRegisters.Where(t => t.IdUser == idUserLog).OrderByDescending(m => m.Id ).First().Id;
        var record = _context.TimeRegisters.FirstOrDefault(m => m.Id == idRecords);
        record.LogoutAt = DateTime.Now;
        _context.TimeRegisters.Update(record);
        _context.SaveChanges();
        HttpContext.Session.Remove("userLog");
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}