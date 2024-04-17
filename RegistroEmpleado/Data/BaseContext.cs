using Microsoft.EntityFrameworkCore;
using RegistroEmpleado.Models;

namespace RegistroEmpleado.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){

        }
        public DbSet<TimeRegister>TimeRegisters { get; set; }
        public DbSet<User>Users { get; set; }

    }
}

