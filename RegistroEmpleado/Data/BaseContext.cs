using Microsoft.EntityFrameworkCore;
using RegistroEmpleado.Models;

namespace RegistroEmpleado.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}

