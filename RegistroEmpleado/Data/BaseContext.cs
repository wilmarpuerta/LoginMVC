using Microsoft.EntityFrameworkCore;
using RegistroEmpleado.Models;

namespace RegistroEmpleado.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){

        }
        public DbSet<Admin> Admins { get; set; }
<<<<<<< HEAD
        public DbSet<Employee> Employees { get; set; }
=======
        public DbSet<Employee> Empleoyees { get; set; }
>>>>>>> b01de1da1e6640331419973db0ac180da4485bbc

    }
}

