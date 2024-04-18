namespace RegistroEmpleado.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public int TipoUser { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Names { get; set; }
        public string? LastNames { get; set; }
        public string? PhotoProfile { get; set; }
        public string? Password { get; set; }

    }
}