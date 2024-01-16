using System;

namespace AskAMech.Core.Domain
{
    public class ViewUserProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string About { get; set; }
        public int UserRoleId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastLoggedIn { get; set; }
        public int MembershipDuration { get; set; }
        public int QuestionCount { get; set; }
        public int AnswerCount { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
