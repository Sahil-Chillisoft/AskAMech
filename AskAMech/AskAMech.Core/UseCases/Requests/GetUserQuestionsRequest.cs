namespace AskAMech.Core.UseCases.Requests
{
    public class GetUserQuestionsRequest
    {
        public int UserId { get; set; }
        public Pagination Pagination { get; set; }
        public bool IsFirstLoad { get; set; }
    }
}
