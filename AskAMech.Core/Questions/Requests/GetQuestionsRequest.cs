namespace AskAMech.Core.Questions.Requests
{
    public class GetQuestionsRequest
    {
        public string Search { get; set; }
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
