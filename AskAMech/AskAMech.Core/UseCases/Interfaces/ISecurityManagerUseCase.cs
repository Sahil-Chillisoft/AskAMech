namespace AskAMech.Core.UseCases.Interfaces
{
    public interface ISecurityManagerUseCase
    {
        void VerifyUserIsAdmin(IPresenter presenter);
        void VerifyUserIsMechanicOrGeneralUser(IPresenter presenter);
        void VerifyUserIsAuthenticated(IPresenter presenter);
    }
}
