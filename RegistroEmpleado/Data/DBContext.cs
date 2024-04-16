using Microsoft.EntityFrameworkCore;

namespace RegistroEmpleado.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
        
    }
    
}