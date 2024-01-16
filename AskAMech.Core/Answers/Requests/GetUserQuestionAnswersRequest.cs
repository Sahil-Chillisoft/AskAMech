namespace AskAMech.Core.Answers.Requests
{
    public class GetUserQuestionAnswersRequest
    {
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
