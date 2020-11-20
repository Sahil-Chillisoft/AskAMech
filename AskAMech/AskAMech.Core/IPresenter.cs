namespace AskAMech.Core
{
    public interface IPresenter
    {
        void Success<TResponse>(TResponse response);
        void Error<TResponse>(TResponse response, bool hasValidationErrors);
        void Error(bool hasValidationErrors);
    }
}
