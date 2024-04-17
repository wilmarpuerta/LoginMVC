namespace RegistroEmpleado.Models;

public class TimeRegister
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public DateTime LoginAt { get; set; }
    public DateTime LogoutAt { get; set; }
}