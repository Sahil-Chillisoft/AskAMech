namespace AskAMech.Core.Answers.Requests
{
    public class EditAnswerRequest
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string Description { get; set; }
    }
}
