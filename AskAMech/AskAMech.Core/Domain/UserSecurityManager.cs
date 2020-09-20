using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.Domain
{
    public sealed class UserSecurityManager
    {
        public UserSecurityManager(int userId, string username, bool isAuthenticated)
        {
            UserId = userId;
            Username = username;
            IsAuthenticated = isAuthenticated;
        }

        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static bool IsAuthenticated { get; private set; } = false;

        public static void SignOut()
        {
            UserSecurityManager userSecurity = new UserSecurityManager(0, string.Empty, false);
        }
    }
}
