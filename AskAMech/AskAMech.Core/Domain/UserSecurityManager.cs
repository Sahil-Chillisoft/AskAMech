namespace AskAMech.Core.Domain
{
    public sealed class UserSecurityManager
    {
        public UserSecurityManager(int userId, string username, int userRoleId, bool isAuthenticated)
        {
            UserId = userId;
            Username = username;
            UserRoleId = userRoleId;
            IsAuthenticated = isAuthenticated;
        }

        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static int UserRoleId { get; set; }
        public static bool IsAuthenticated { get; set; } = false;

    }
}
