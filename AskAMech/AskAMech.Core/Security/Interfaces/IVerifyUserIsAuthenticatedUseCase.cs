namespace AskAMech.Core.Security.Interfaces
{
    public interface IVerifyUserIsAuthenticatedUseCase
    {
        void IsAuthenticated(IPresenter presenter);
    }
}
