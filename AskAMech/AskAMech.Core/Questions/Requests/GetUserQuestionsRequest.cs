namespace AskAMech.Core.Questions.Requests
{
    public class GetUserQuestionsRequest
    {
        public int UserId { get; set; }
        public Pagination Pagination { get; set; }
        public bool IsFirstLoad { get; set; }
        public int CategoryId { get; set; }
    }
}
