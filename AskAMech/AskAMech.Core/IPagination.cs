namespace AskAMech.Core
{
    public interface IPagination
    {
        Pagination GetEntityPagination(Pagination pagination, params object[] filters);
    }
}
