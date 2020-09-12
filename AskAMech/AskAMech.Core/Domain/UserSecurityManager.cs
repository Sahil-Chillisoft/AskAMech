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

        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static bool IsAuthenticated { get; set; } = false;
    }
}
