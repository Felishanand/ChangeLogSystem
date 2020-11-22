namespace ChangeLogSystem.Domain.Models
{
    public interface IUserModel
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }
}