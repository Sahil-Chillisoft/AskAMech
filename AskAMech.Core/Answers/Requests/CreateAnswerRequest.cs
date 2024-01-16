namespace AskAMech.Core.Answers.Requests
{
    public class CreateAnswerRequest
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
    }
}
