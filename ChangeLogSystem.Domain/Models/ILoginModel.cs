namespace ChangeLogSystem.Business.Models
{
    public interface ILoginModel
    {
        int UserId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}