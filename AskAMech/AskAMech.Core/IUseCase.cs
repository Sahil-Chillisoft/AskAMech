namespace AskAMech.Core
{
    public interface IUseCase<in TRequest>
    {
        void Execute(TRequest request, IPresenter presenter);
    }
}
