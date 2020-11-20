namespace AskAMech.Core.Security
{
    public interface ISecurityManagerUseCase
    {
        void VerifyUserIsAdmin(IPresenter presenter);
        void VerifyUserIsMechanicOrGeneralUser(IPresenter presenter);
        void VerifyUserIsAuthenticated(IPresenter presenter);
    }
}
