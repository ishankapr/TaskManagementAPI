namespace TaskManagement.Models
{
    public class AuthResponse
    {
        public bool IsAuthenticated { get; set; }
        public User? User { get; set; }
    }
}
