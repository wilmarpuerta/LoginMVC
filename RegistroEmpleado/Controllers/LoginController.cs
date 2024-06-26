﻿using System.Security.Claims;
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
        if ( HttpContext.Session.GetString("UserLog") != null)
        {
            var idUser = int.Parse(HttpContext.Session.GetString("UserLog")!);
            var user = _context.Users.FirstOrDefault(u => u.Id == idUser);
            if (user?.TipoUser == 1)
            {
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                return RedirectToAction("Index", "Users");
            }
            
        }
        
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Acceder(string username, string password, TimeRegister time)
    {

        var userfind = await _context.Users.FirstOrDefaultAsync(u => u.Names == username && u.Password == password);
        
        if (userfind != null)
        {
            HttpContext.Session.SetString("UserLog", userfind.Id.ToString());
            time.IdUser = userfind.Id;
            time.LoginAt = DateTime.Now;
            time.LogoutAt = null;
            _context.TimeRegisters.Add(time);
            _context.SaveChanges();
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };
            if (userfind.TipoUser == 1)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "Employee"));
            }
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
 
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            
            if (userfind.TipoUser == 1)
            {
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
        var record = _context.TimeRegisters.First(m => m.Id == int.Parse(HttpContext.Session.GetString("RecordUser")!));
        record.LogoutAt = DateTime.Now;
        _context.TimeRegisters.Update(record);
        await _context.SaveChangesAsync();
        HttpContext.Session.Remove("UserLog");
        HttpContext.Session.Remove("RecordUser");
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}