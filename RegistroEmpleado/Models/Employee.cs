namespace RegistroEmpleado.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Names { get; set; }
        public string? LastNames { get; set; }
        public string? PhotoProfile { get; set; }
        public string? Password { get; set; }
        public DateTime? LoginAt { get; set; }
        public DateTime? LogOffAt { get; set; }

    }
}