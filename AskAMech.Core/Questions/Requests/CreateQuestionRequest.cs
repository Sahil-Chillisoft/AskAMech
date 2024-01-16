namespace AskAMech.Core.Questions.Requests
{
    public class CreateQuestionRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
