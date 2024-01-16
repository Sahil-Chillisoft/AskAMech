namespace AskAMech.Core
{
    public interface IReadOnlyUseCase
    {
        void Execute(IPresenter presenter);
    }
}
