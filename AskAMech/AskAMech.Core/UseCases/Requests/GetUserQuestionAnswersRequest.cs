namespace AskAMech.Core.UseCases.Requests
{
    public class GetUserQuestionAnswersRequest
    {
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
