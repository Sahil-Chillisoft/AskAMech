namespace AskAMech.Core.Users.Requests
{
    public class UpdateUserPasswordRequest
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
