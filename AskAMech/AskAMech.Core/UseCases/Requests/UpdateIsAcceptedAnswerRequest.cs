namespace AskAMech.Core.UseCases.Requests
{
    public class UpdateIsAcceptedAnswerRequest
    {
        public bool IsAcceptedAnswer { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
