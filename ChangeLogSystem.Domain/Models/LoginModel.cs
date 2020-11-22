namespace ChangeLogSystem.Domain.Models
{
    public class LoginModel : ILoginModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}