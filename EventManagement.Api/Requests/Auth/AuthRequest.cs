using EventManagement.Domain.Entities.Users;

namespace EventManagement.Api.Requests.Auth
{
    public class RegisterRequest
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public UserRole Role { get; set; }
    }
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
