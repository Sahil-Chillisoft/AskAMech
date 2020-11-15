namespace AskAMech.Core.UseCases.Requests
{
    public class EditQuestionRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
